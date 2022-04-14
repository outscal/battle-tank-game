using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    internal static class EditorTools
    {
        /// <summary>
        /// Makes an object editable. (Usefull for object managed by Importers)
        /// </summary>
        /// <param name="pObject"></param>
        public static void OverrideReadOnlyFlag(Object unityObject)
        {
            unityObject.hideFlags &= ~HideFlags.NotEditable;
        }

        public static SubstanceMaterialInstanceSO CreateSubstanceInstance(string assetPath, SubstanceFileRawData fileData,string name, bool isRoot = false)
        {
            var instanceAsset = ScriptableObject.CreateInstance<SubstanceMaterialInstanceSO>();
            instanceAsset.AssetPath = assetPath;
            instanceAsset.RawData = fileData; 
            instanceAsset.Name = name;
            instanceAsset.IsRoot = isRoot;
            instanceAsset.RefreshMaterial = true;
            instanceAsset.GUID = System.Guid.NewGuid().ToString();
            instanceAsset.OutputPath = CreateGraphFolder(assetPath, name);
            var instancePath = MakeRootGraphAssetPath(instanceAsset);
            SubstanceEditorEngine.instance.InitializeInstance(instanceAsset, instancePath);
            instanceAsset.Graphs = SubstanceEditorEngine.instance.CreateInstanceGraphs(instanceAsset);
            AssetDatabase.CreateAsset(instanceAsset, instancePath);
            return instanceAsset;
        }

        public static void Rename(this SubstanceMaterialInstanceSO substanceMaterial, string name)
        {
            var oldFolder = substanceMaterial.OutputPath;

            if (substanceMaterial.Name == name)
                return;

            substanceMaterial.Name = name;

            var dir = Path.GetDirectoryName(substanceMaterial.AssetPath);
            var assetName = Path.GetFileNameWithoutExtension(substanceMaterial.AssetPath);
            var newFolder = Path.Combine(dir, $"{assetName}_{name}");
            substanceMaterial.OutputPath = newFolder;

            FileUtil.MoveFileOrDirectory(oldFolder, substanceMaterial.OutputPath);
            File.Delete($"{oldFolder}.meta");

            EditorUtility.SetDirty(substanceMaterial);
            AssetDatabase.Refresh();

            var oldPath = AssetDatabase.GetAssetPath(substanceMaterial);
            var error = AssetDatabase.RenameAsset(oldPath, $"{name}.asset");

            if (!string.IsNullOrEmpty(error))
                Debug.LogError(error);

            foreach (var graph in substanceMaterial.Graphs)
            {
                var materialOldName = AssetDatabase.GetAssetPath(graph.OutputMaterial);
                var materialNewName = Path.GetFileName(graph.GetAssociatedAssetPath($"{name}_material", "mat"));
                error = AssetDatabase.RenameAsset(materialOldName, materialNewName);
                EditorUtility.SetDirty(graph.OutputMaterial);

                if (!string.IsNullOrEmpty(error))
                    Debug.LogError(error);
            }

            AssetDatabase.Refresh();
        }

        public static void Move(this SubstanceMaterialInstanceSO substanceMaterial, string to)
        {
            substanceMaterial.OutputPath = Path.GetDirectoryName(to);

            foreach (var graph in substanceMaterial.Graphs)
            {
                var oldMaterialPath = AssetDatabase.GetAssetPath(graph.OutputMaterial);
                AssetDatabase.MoveAsset(oldMaterialPath, Path.Combine(graph.OutputPath, Path.GetFileName(oldMaterialPath)));

                foreach (var output in graph.Output)
                {
                    var textureAssetPath = AssetDatabase.GetAssetPath(output.OutputTexture);
                    var textureFileName = Path.GetFileName(textureAssetPath);
                    var newTexturePath = Path.Combine(graph.OutputPath, textureFileName);
                    AssetDatabase.MoveAsset(textureAssetPath, newTexturePath);
                }
            }

            EditorUtility.SetDirty(substanceMaterial);
            AssetDatabase.Refresh();
        }

        private static string CreateGraphFolder(string assetPath, string graphName)
        {
            var dir = Path.GetDirectoryName(assetPath);
            var assetName = Path.GetFileNameWithoutExtension(assetPath);

            var newFolder = Path.Combine(dir, $"{assetName}_{graphName}");

            if (Directory.Exists(newFolder))
                return newFolder;

            string guid = AssetDatabase.CreateFolder(dir, $"{assetName}_{graphName}");
            return AssetDatabase.GUIDToAssetPath(guid);
        }

        private static string MakeRootGraphAssetPath(SubstanceMaterialInstanceSO substanceMaterial)
        {
            return Path.Combine(substanceMaterial.OutputPath, $"{substanceMaterial.Name}.asset");
        }
    }
}