using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Adobe.Substance.Input;
using System.IO;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

#if UNITY_EDITOR

using Unity.Collections.LowLevel.Unsafe;

#endif

namespace Adobe.Substance
{
    [System.Serializable]
    public class SubstanceGraph
    {
        [SerializeField]
        public int Index;

        [SerializeField]
        public SubstanceMaterialInstanceSO Owner;

        [SerializeReference]
        public List<ISubstanceInput> Input = default;

        [SerializeField]
        public List<SubstanceOutputTexture> Output = default;

        [SerializeField, HideInInspector]
        public bool RenderTextures = false;

        [SerializeField, HideInInspector]
        public bool OutputRemaped = false;

        [SerializeField]
        public byte[] Thumbnail = default;

        [SerializeField]
        public bool HasThumbnail = false;

        [SerializeField]
        public Material OutputMaterial = default;

        [SerializeField]
        public string MaterialShader = default;

        [SerializeField]
        public bool GenerateAllOutputs = false;

        [SerializeField]
        public bool GenerateAllMipmaps = false;

        [SerializeField]
        public string DefaultPreset = default;

        /// <summary>
        /// Preset that holds the current state of the inputs. (Editor only)
        /// </summary>
        [SerializeField]
        public string CurrentStatePreset = default;

        public string FilePath
        {
            get
            {
                if (Owner != null)
                    return Owner.AssetPath;

                return null;
            }
        }

        public string OutputPath
        {
            get
            {
                if (Owner != null)
                    return Owner.OutputPath;

                return null;
            }
        }

        /// <summary>
        /// If true, this asset will not generate tga files for the output textures.
        /// </summary>
        [SerializeField]
        public bool IsRuntimeOnly = false;

        public SubstanceGraph(SubstanceMaterialInstanceSO owner, int index)
        {
            Index = index;
            Owner = owner;
        }

        /// <summary>
        /// Initialized the substance graph. Uses the native handle to set all the input parameters, configure output textures, create Unity Texture2D objects for each output and properly assign them to the target material.
        /// This must be called if the substance graph was flagged as Runtime only and will require its assets be generated at runtime.
        /// </summary>
        /// <param name="handler">Handle to a native substance object.</param>
        public void RuntimeInitialize(SubstanceNativeHandler handler)
        {
            foreach (var input in Input)
                input.UpdateNativeHandle(handler);

            RenderingUtils.ConfigureOutputTextures(handler, this);
            var result = handler.Render(Index);
            CreateAndUpdateOutputTextures(result, handler);
            MaterialUtils.AssignOutputTexturesToMaterial(this);
        }

        public Texture2D GetThumbnailTexture()
        {
            if (!HasThumbnail)
                return null;

            Texture2D thumbnailTexture = new Texture2D(0, 0);
            thumbnailTexture.LoadImage(Thumbnail);
            return thumbnailTexture;
        }

        public void CreateAndUpdateOutputTextures(IntPtr resultPtr, SubstanceNativeHandler handler)
        {
            unsafe
            {
                for (int i = 0; i < Output.Count; i++)
                {
                    var output = Output[i];

                    if (!output.IsStandardOutput && !GenerateAllOutputs)
                        continue;

                    var index = output.VirtualOutputIndex;
                    IntPtr pI = resultPtr + (index * sizeof(NativeData));
                    NativeData data = Marshal.PtrToStructure<NativeData>(pI);

                    if (data.ValueType != ValueType.SBSARIO_VALUE_IMAGE)
                    {
                        Debug.LogError($"Skiping render index #{index} of {output.Description.Channel} because it was not an image");
                        continue;
                    }

                    if (data.ValueType == ValueType.SBSARIO_VALUE_IMAGE)
                    {
                        NativeDataImage imgData = data.Data.ImageData;
                        output.BGRATexture = imgData.channel_order == ChannelOrder.SBSARIO_CHANNEL_ORDER_BGRA;

                        if (output.BGRATexture)
                            handler.ChangeOutputRBChannels(Index, output.VirtualOutputIndex);

                        if (TryGetUnityTextureFormat(imgData, IsRuntimeOnly, out int width, out int height, out int imageSize, out TextureFormat format, out int mipsCount))
                        {
                            var texture = new Texture2D(width, height, format, true, output.sRGB);
#if UNITY_EDITOR
                            texture.alphaIsTransparency = imgData.image_format.ChannelCount() == 4;
#endif
                            output.OutputTexture = texture;
                            texture.Apply();
                        }
                    }
                }
            }

            UpdateOutputTextures(resultPtr);
        }

        public void UpdateOutputTextures(IntPtr renderResultPtr)
        {
            unsafe
            {
                ConcurrentQueue<Texture2D> results = new ConcurrentQueue<Texture2D>();

                int updatesCount = 0;

                foreach (var output in Output)
                {
                    var texture = output.OutputTexture;

                    if (texture == null)
                        continue;

                    var index = output.VirtualOutputIndex;
                    IntPtr pI = renderResultPtr + (index * sizeof(NativeData));
                    NativeData data = Marshal.PtrToStructure<NativeData>(pI);

                    if (data.ValueType != ValueType.SBSARIO_VALUE_IMAGE)
                    {
                        Debug.LogError($"Results fail for {output.Description.Label}");
                        continue;
                    }

                    NativeDataImage srcImage = data.Data.ImageData;
                    var dstData = texture.GetSubstanceHandler();

                    _ = Task.Run(() =>
                    {
                        var dstImage = dstData.ImageData;
                        NativeMethods.sbsario_sbsar_utils_copy_texture(ref srcImage, ref dstImage, output.Flags);
#if UNITY_EDITOR
                        AtomicSafetyHandle.Release(dstData.AtomicHandler);
#endif
                        results.Enqueue(texture);
                    });

                    updatesCount++;
                }

                while (updatesCount != 0)
                {
                    //As updates get done we start uploading textures to the GPU.
                    while (results.TryDequeue(out Texture2D texture))
                    {
                        texture.Apply();
                        updatesCount--;
                    }
                }
            }
        }

        public List<(int, Vector2Int)> CheckIfTexturesResize(IntPtr resultPtr)
        {
            List<(int, Vector2Int)> textureSizes = new List<(int, Vector2Int)>();

            unsafe
            {
                foreach (var output in Output)
                {
                    var texture = output.OutputTexture;

                    if (texture == null)
                        continue;

                    var index = output.VirtualOutputIndex;
                    IntPtr pI = resultPtr + (index * sizeof(NativeData));
                    NativeData data = Marshal.PtrToStructure<NativeData>(pI);

                    if (data.ValueType != ValueType.SBSARIO_VALUE_IMAGE)
                    {
                        Debug.LogError($"Results fail for {output.Description.Label}");
                        continue;
                    }

                    NativeDataImage imgData = data.Data.ImageData;

                    if (imgData.channel_order == ChannelOrder.SBSARIO_CHANNEL_ORDER_BGRA)
                        output.BGRATexture = true;

                    if (texture.width != (int)imgData.width || texture.height != (int)imgData.height)
                        textureSizes.Add((output.Index, new Vector2Int((int)imgData.width, (int)imgData.height)));
                }
            }

            return textureSizes;
        }

        /// <summary>
        /// Updates the IsVisible property of all inputs.
        /// </summary>
        /// <param name="handler">Handle to a substance file.</param>
        public void RefreshInputVisibility(SubstanceNativeHandler handler)
        {
            foreach (var input in Input)
            {
                if (!input.IsValid)
                {
                    input.IsVisible = false;
                    continue;
                }

                var inputID = input.Index;

                if (string.IsNullOrEmpty(input.Description.GuiVisibleIf))
                    input.IsVisible = true;

                input.IsVisible = handler.IsInputVisible(Index, inputID);
            }
        }

        private static bool TryGetUnityTextureFormat(NativeDataImage nativeData, bool isRuntime, out int width, out int height, out int imageSize, out TextureFormat format, out int mipsCount)
        {
            width = (int)nativeData.width;
            height = (int)nativeData.height;
            mipsCount = (int)nativeData.mipmaps;

            imageSize = nativeData.GetSizeWithMipMaps();

            if (nativeData.channel_order == ChannelOrder.SBSARIO_CHANNEL_ORDER_BGRA)
                format = isRuntime ? TextureFormat.RGBA32 : TextureFormat.BGRA32;
            else
                format = nativeData.image_format.ToUnityFormat();

            if (format == TextureFormat.R8 || format == TextureFormat.R16)
                format = TextureFormat.RGB24;

            //Mobile do not support 64 bit pixel format.
            //#if ((UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR)
            if (format == TextureFormat.RGBA64)
                format = TextureFormat.RGBA32;
            //#endif
            return true;
        }
    }
}