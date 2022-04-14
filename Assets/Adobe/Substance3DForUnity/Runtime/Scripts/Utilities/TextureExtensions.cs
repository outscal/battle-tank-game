using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Profiling;
using UnityEngine;

namespace Adobe.Substance
{
    /// <summary>
    /// Provides utility extensions to copy data from substance to unity textures.
    /// </summary>
    internal static class TextureExtensions
    {
        public static TextureNativeData GetSubstanceHandler(this Texture2D texture)
        {
            unsafe
            {
#if UNITY_2020_1_OR_NEWER
                NativeArray<byte> textureData = texture.GetPixelData<byte>(0);
#else
                NativeArray<byte> textureData = texture.GetRawTextureData<byte>();
#endif

#if UNITY_EDITOR
                var atomicSafetyHandler = NativeArrayUnsafeUtility.GetAtomicSafetyHandle(textureData);

                if (!AtomicSafetyHandle.GetAllowReadOrWriteAccess(atomicSafetyHandler))
                {
                    atomicSafetyHandler = AtomicSafetyHandle.Create();
                    NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref textureData, atomicSafetyHandler);
                }
#endif

                void* dst_ptr = NativeArrayUnsafeUtility.GetUnsafePtr(textureData);

                var dst_order = texture.format.GetChannelOrder();
                var dst_format = texture.format.ToSubstance();

                NativeDataImage dstImage = new NativeDataImage
                {
                    channel_order = dst_order,
                    image_format = dst_format,
                    width = (IntPtr)texture.width,
                    height = (IntPtr)texture.height,
                    data = (IntPtr)dst_ptr,
                    mipmaps = (IntPtr)texture.mipmapCount
                };

                return new TextureNativeData
                {
                    ImageData = dstImage,
#if UNITY_EDITOR
                    AtomicHandler = atomicSafetyHandler
#endif
                };
            }
        }

        internal static byte[] Color32ArrayToByteArray(Color32[] colors)
        {
            if (colors == null || colors.Length == 0)
                return null;

            int length = Marshal.SizeOf(typeof(Color32)) * colors.Length;
            byte[] bytes = new byte[length];

            GCHandle handle = default(GCHandle);
            try
            {
                handle = GCHandle.Alloc(colors, GCHandleType.Pinned);
                IntPtr ptr = handle.AddrOfPinnedObject();
                Marshal.Copy(ptr, bytes, 0, length);
            }
            finally
            {
                if (handle != default(GCHandle))
                    handle.Free();
            }

            return bytes;
        }

        internal static Color32[] FlipY(Texture2D pInput)
        {
            try
            {
                Color32[] input = pInput.GetPixels32(0);
                Color32[] output = new Color32[input.Length];
                int width = pInput.width;   // length (in bytes) of each line

                for (int y = 0, i = 0, o = output.Length - width; y < pInput.height; y++, i += width, o -= width)
                    Array.Copy(input, i, output, o, width);

                return output;
            }
            catch (UnityException e)
            {
                if (e.Message.StartsWith("Texture '" + pInput.name + "' is not readable"))
                {
                    Debug.LogError("Please enable read/write on texture [" + pInput.name + "]");
                }
            }

            return null;
        }
    }

    internal struct TextureNativeData
    {
        public NativeDataImage ImageData;

#if UNITY_EDITOR
        public AtomicSafetyHandle AtomicHandler;
#endif
    }
}