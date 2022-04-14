using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    internal static class TextureUtils
    {
        public static bool IsCompressed(this TextureFormat unityFormat)
        {
            switch (unityFormat)
            {
                case TextureFormat.RGBA32:
                case TextureFormat.RGBA64:
                case TextureFormat.RGB24:
                case TextureFormat.BGRA32:
                case TextureFormat.R8:
                case TextureFormat.R16:
                case TextureFormat.RFloat:
                    return false;

                default:
                    return true;
            }
        }

        public static Texture2D MakeUncompressed(Texture2D pTexture)
        {
            Texture2D texture = pTexture;

            if (pTexture == null)
                return null;

            string assetPath = AssetDatabase.GetAssetPath(pTexture);

            var textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (textureImporter != null)
            {
                if (textureImporter.textureCompression == TextureImporterCompression.Uncompressed)
                    return pTexture;

                textureImporter.textureCompression = TextureImporterCompression.Uncompressed;

                Debug.LogWarning(string.Format("Setting {0}'s 'Compression' flag to Uncompressed", pTexture.name));

                EditorUtility.SetDirty(textureImporter);
                AssetDatabase.ImportAsset(assetPath);
                AssetDatabase.Refresh();

                texture = AssetDatabase.LoadMainAssetAtPath(assetPath) as Texture2D;
            }

            return texture;
        }

        public static Texture2D SetReadableFlag(Texture2D pTexture, bool pReadable)
        {
            Texture2D texture = pTexture;

            if (pTexture == null)
                return null;

            string assetPath = AssetDatabase.GetAssetPath(pTexture);

            var textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
            if (textureImporter != null)
            {
                if (textureImporter.isReadable == pReadable)
                    return pTexture;

                textureImporter.isReadable = pReadable;
                Debug.LogWarning(string.Format("Setting {0}'s 'Read/Write Enabled' flag to {1}",
                                                pTexture.name, (pReadable ? "true" : "false")));

                EditorUtility.SetDirty(textureImporter);
                AssetDatabase.ImportAsset(assetPath);
                AssetDatabase.Refresh();

                texture = AssetDatabase.LoadMainAssetAtPath(assetPath) as Texture2D;
            }

            return texture;
        }

        public static Texture2D EnforceMaxResolution(Texture2D pTexture)
        {
            Texture2D texture = pTexture;

            if (pTexture == null)
                return null;

            string assetPath = AssetDatabase.GetAssetPath(pTexture);

            var textureImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;

            if (textureImporter != null)
            {
                if (textureImporter.maxTextureSize >= 4096)
                    return pTexture;

                textureImporter.maxTextureSize = 4096;

                Debug.LogWarning(string.Format("Setting {0}'s 'Max Texture Size' flag to 4096", pTexture.name));

                EditorUtility.SetDirty(textureImporter);
                AssetDatabase.ImportAsset(assetPath);
                AssetDatabase.Refresh();

                texture = AssetDatabase.LoadMainAssetAtPath(assetPath) as Texture2D;
            }

            return texture;
        }
    }
}