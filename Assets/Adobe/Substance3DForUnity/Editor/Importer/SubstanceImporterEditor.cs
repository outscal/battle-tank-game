using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Text.RegularExpressions;

#if UNITY_2020_2_OR_NEWER

using UnityEditor.AssetImporters;

#else
using UnityEditor.Experimental.AssetImporters;
#endif

namespace Adobe.Substance.Editor.Importer
{
    [CustomEditor(typeof(SubstanceImporter)), CanEditMultipleObjects]
    internal class SubstanceImporterEditor : ScriptedImporterEditor
    {
        protected override bool needsApplyRevert => false;

        public override bool showImportedObject => false;

        private int _selectedInstance = 0;

        //Size of the preview thumbnail for instances in the list.
        private const int _instanceListPreviewSize = 64;

        private const int _isntanceListElementSpacing = 0;

        private Vector2 _scrollPosition = Vector2.zero;

        public SubstanceImporter _importer;

        private bool _hasChanged = false;

        public string _tempLabelName;

        private Dictionary<SubstanceMaterialInstanceSO, SubstanceMaterialInstanceEditor> _elementsEditors;

        private Dictionary<SubstanceMaterialInstanceSO, MaterialEditor> _previewEditors;

        private SubstanceMaterialInstanceEditor _currentEditor;

        private Texture2D _backgroundImage = default;

        private Texture2D _textHightlightBackground = default;

        public override void OnEnable()
        {
            base.OnEnable();

            _elementsEditors = new Dictionary<SubstanceMaterialInstanceSO, SubstanceMaterialInstanceEditor>();
            _previewEditors = new Dictionary<SubstanceMaterialInstanceSO, MaterialEditor>();
            _importer = target as SubstanceImporter;

            EditorApplication.projectWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
            EnsureRefreshedMaterials();
            EnsureRequiredTextures();
        }

        public override void OnDisable()
        {
            EditorApplication.projectWindowItemOnGUI -= OnHierarchyWindowItemOnGUI;
            base.OnDisable();

            if (_hasChanged)
                _importer.SaveAndReimport();
        }

        protected static void OnHierarchyWindowItemOnGUI(string guid, Rect rt)
        {
            var currentEvent = Event.current;

            if ("Duplicate" == currentEvent.commandName && currentEvent.type == EventType.ExecuteCommand)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);

                if (Path.GetExtension(assetPath) == ".sbsar")
                {
                    Debug.LogWarning("Substance graph can not be manually duplicated.");
                    currentEvent.Use();
                }
            }
        }

        #region Draw Body

        public override void OnInspectorGUI()
        {
            DrawMainUI();
        }

        private void DrawMainUI()
        {
            if (_importer._instancesCopy.Count == 0)
                return;

            EditorGUILayout.BeginVertical();
            {
                //Draw instances list.
                EditorGUILayout.BeginVertical();
                DrawInstancesListSection();
                EditorGUILayout.EndVertical();
                DrawUILine();

                //Draw shader UI.
                EditorGUILayout.BeginHorizontal();
                DrawShaderSelectionSection();
                EditorGUILayout.EndHorizontal();
                DrawUILine();

                //Draw selected instance properties.
                EditorGUILayout.BeginVertical();
                DrawSelectedInstanceProperties(_importer._instancesCopy[_selectedInstance]);
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
        }

        private void DrawInstancesListSection()
        {
            int numGraphs = _importer._instancesCopy.Count;

            if (numGraphs == 0)
                return;

            //Instance UI width = preview texture size + padding.
            float entryWidth = _instanceListPreviewSize + 16;

            //Instance UI height = preview texture size + name text.
            float entryHeight = _instanceListPreviewSize + EditorGUIUtility.singleLineHeight;

            EditorGUILayout.LabelField("Substance Graphs");
            EditorGUILayout.Space();

            using (var scrollViewScope = new EditorGUILayout.ScrollViewScope(_scrollPosition, false, false))
            {
                scrollViewScope.handleScrollWheel = false;
                _scrollPosition = scrollViewScope.scrollPosition;

                var listStyle = new GUIStyle();
                listStyle.padding = new RectOffset(15, 15, 15, 15);

                var rect = EditorGUILayout.BeginHorizontal(listStyle);
                {
                    //Gray area
                    var targetRect = new Rect(rect.x + 5, rect.y, rect.width - 10, rect.height);
                    DrawGrayRectangle(targetRect);

                    //Text styles
                    var normalTextStyle = new GUIStyle();
                    normalTextStyle.wordWrap = true;
                    normalTextStyle.alignment = TextAnchor.MiddleCenter;

                    if (EditorGUIUtility.isProSkin)
                        normalTextStyle.normal.textColor = new Color(0.8f, 0.8f, 0.8f, 1);

                    var highlightTextStyle = new GUIStyle();
                    highlightTextStyle.alignment = TextAnchor.MiddleCenter;
                    highlightTextStyle.normal.textColor = Color.white;
                    highlightTextStyle.normal.background = _textHightlightBackground;
                    highlightTextStyle.wordWrap = true;

                    for (int instanceIndex = 0; instanceIndex < numGraphs; instanceIndex++)
                    {
                        if (TryGetInstanceByIndex(instanceIndex, out SubstanceMaterialInstanceSO instance))
                        {
                            EditorGUILayout.BeginVertical(GUILayout.Width(entryWidth), GUILayout.Height(entryHeight));
                            {
                                DrawListElement(instance, instanceIndex, entryWidth - 12, normalTextStyle, highlightTextStyle);
                            }
                            EditorGUILayout.EndVertical();
                            GUILayout.Space(_isntanceListElementSpacing);
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            DrawAddAndRemove();
            EditorGUILayout.EndHorizontal();
        }

        private void DrawGrayRectangle(Rect rect)
        {
            var style = new GUIStyle();
            style.normal.background = _backgroundImage;
            GUI.Box(rect, GUIContent.none, style);
        }

        private void DrawListElement(SubstanceMaterialInstanceSO instance, int instanceIndex, float entryWidth, GUIStyle normalStyle, GUIStyle highlightStyle)
        {
            var graphInstance = instance.Graphs[0];
            Material graphMaterial = graphInstance.OutputMaterial;

            if (graphMaterial == null)
                return;

            Texture2D miniThumbnail = AssetPreview.GetAssetPreview(graphMaterial);

            if (GUILayout.Button(miniThumbnail, GUILayout.Width(_instanceListPreviewSize),
                                                GUILayout.Height(_instanceListPreviewSize)))
            {
                OnInstanceSelected(instanceIndex);
            }

            if (instanceIndex != _selectedInstance)
            {
                GUILayout.Label(instance.Name, normalStyle, GUILayout.Width(entryWidth));
                return;
            }

            var label = _tempLabelName ?? instance.Name;
            _tempLabelName = GUILayout.TextField(label, highlightStyle, GUILayout.Width(entryWidth));

            Event e = Event.current;
            if (e.keyCode == KeyCode.Return)
            {
                if (e.type == EventType.KeyUp)
                {
                    if (!TryRenameInstance(instance, _tempLabelName))
                    {
                        EditorUtility.DisplayDialog("Error", "The provided name can't be assigned to a substance instance.", "Ok");
                        _tempLabelName = instance.Name;
                    }
                }
            }
        }

        private void DrawAddAndRemove()
        {
            if (GUILayout.Button("Create new instance"))
            {
                CreateNewInstance();
                GUIUtility.ExitGUI();
            }

            if (GUILayout.Button("Delete instance"))
            {
                if (TryGetSelectedInstance(out SubstanceMaterialInstanceSO instanceSO))
                {
                    DeleteInstance(instanceSO);
                    GUIUtility.ExitGUI();
                }
            }
        }

        private void DrawShaderSelectionSection()
        {
            EditorGUILayout.LabelField("Shader", GUILayout.Width(55));

            if (!TryGetCurrentGraph(out SubstanceGraph graph))
                return;

            if (graph.OutputMaterial == null || graph.OutputMaterial.shader == null)
                return;

            var currentShader = graph.OutputMaterial.shader;

            var shaderNames = ShaderUtil.GetAllShaderInfo().Select((a) => a.name).Where(b => !b.StartsWith("Hidden") && !b.StartsWith("GUI")).ToArray();
            var selectedElement = shaderNames.FirstOrDefault(a => a == currentShader.name);
            var selectedIndex = Array.IndexOf(shaderNames, selectedElement);

            var newSelected = EditorGUILayout.Popup(selectedIndex, shaderNames, GUILayout.MaxWidth(320));

            if (newSelected != selectedIndex)
            {
                var newSelectedElement = shaderNames[newSelected];
                _importer._instancesCopy[_selectedInstance].Graphs[0].OutputMaterial.shader = Shader.Find(newSelectedElement);
                EditorUtility.SetDirty(_importer._instancesCopy[_selectedInstance].Graphs[0].OutputMaterial);
                AssetDatabase.Refresh();
            }

            if (GUILayout.Button("Edit", GUILayout.MaxWidth(60)))
            {
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = currentShader;
            }
        }

        private void DrawSelectedInstanceProperties(SubstanceMaterialInstanceSO currentInstance)
        {
            if (!_elementsEditors.TryGetValue(currentInstance, out SubstanceMaterialInstanceEditor editor))
            {
                editor = SubstanceMaterialInstanceEditor.CreateEditor(currentInstance) as SubstanceMaterialInstanceEditor;
                _elementsEditors.Add(currentInstance, editor);
            }

            if (_currentEditor != null && _currentEditor != editor)
                _currentEditor.SaveEditorChanges();

            editor.OnInspectorGUI();
            _currentEditor = editor;
        }

        #endregion Draw Body

        #region Static Preview

        public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
        {
            if (_importer == null)
                return null;

            if (_importer._instancesCopy[0] == null)
                return null;

            if (_importer._instancesCopy[0].Graphs[0] == null)
                return null;

            if (_importer._instancesCopy[0].Graphs[0].HasThumbnail)
            {
                return _importer._instancesCopy[0].Graphs[0].GetThumbnailTexture();
            }
            else
            {
                var icon = UnityPackageInfo.GetSubstanceIcon(width, height);

                if (icon != null)
                {
                    Texture2D tex = new Texture2D(width, height);
                    EditorUtility.CopySerialized(icon, tex);
                    return tex;
                }
            }

            return base.RenderStaticPreview(assetPath, subAssets, width, height);
        }

        #endregion Static Preview

        #region Preview

        public override bool HasPreviewGUI()
        {
            return true;
        }

        public override GUIContent GetPreviewTitle()
        {
            if (!TryGetCurrentGraph(out SubstanceGraph graph))
                return new GUIContent("Material", null, "");

            if (graph.OutputMaterial == null)
                return new GUIContent("Material", null, "");

            if (string.IsNullOrEmpty(graph.OutputMaterial.name))
                return new GUIContent("Material", null, "");

            return new GUIContent(graph.OutputMaterial.name, null, "");
        }

        public override void OnPreviewSettings()
        {
            var selectedInstance = _importer._instancesCopy[_selectedInstance];

            if (selectedInstance == null)
                return;

            if (!_previewEditors.TryGetValue(selectedInstance, out MaterialEditor editor))
            {
                var material = selectedInstance?.Graphs[0]?.OutputMaterial;

                if (material != null)
                {
                    editor = MaterialEditor.CreateEditor(material) as MaterialEditor;
                    _previewEditors.Add(selectedInstance, editor);
                }
            }

            if (editor != null)
                editor.OnPreviewSettings();
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            var selectedInstance = _importer._instancesCopy[_selectedInstance];

            if (selectedInstance == null)
                return;

            if (!_previewEditors.TryGetValue(selectedInstance, out MaterialEditor editor))
            {
                var material = selectedInstance?.Graphs[0]?.OutputMaterial;

                if (material != null)
                {
                    editor = MaterialEditor.CreateEditor(material) as MaterialEditor;
                    _previewEditors.Add(selectedInstance, editor);
                }
            }

            if (editor != null)
                editor.OnPreviewGUI(r, background);
        }

        public override void DrawPreview(Rect previewArea)
        {
            OnPreviewGUI(previewArea, new GUIStyle());
        }

        #endregion Preview

        /// <summary>
        /// Creates a new instance of a SubstanceMaterialInstanceSO with a copy of the values from the current selected instance.
        /// </summary>
        /// <param name="name">Name for the new instance.</param>
        /// <param name="currentInstance">Current selected instance.</param>
        private void CreateNewInstance()
        {
            if (!TryGetInstanceByIndex(0, out SubstanceMaterialInstanceSO rootInstance))
                return;

            var newInstanceName = GenerateNewInstanceName(rootInstance);

            var instanceAsset = EditorTools.CreateSubstanceInstance(_importer.assetPath, rootInstance.RawData, newInstanceName);
            _ = SubstanceEditorEngine.instance.RenderInstanceAsync(instanceAsset, 0);

            _importer._instancesCopy.Add(instanceAsset);
            EditorUtility.SetDirty(_importer);
            AssetDatabase.Refresh();
            _hasChanged = true;
            _selectedInstance = _importer._instancesCopy.Count - 1;
            ResetTempName();
        }

        private void DeleteInstance(SubstanceMaterialInstanceSO instance)
        {
            if (instance.IsRoot)
            {
                EditorUtility.DisplayDialog("Invalid operation", "Can't delete root instance.", "OK");
                return;
            }

            _importer._instancesCopy.Remove(instance);
            EditorUtility.SetDirty(_importer);

            SubstanceEditorEngine.instance.ReleaseInstance(instance);
            instance.FlagedForDelete = true;
            EditorUtility.SetDirty(instance);

            var assetPath = AssetDatabase.GetAssetPath(instance);
            AssetDatabase.DeleteAsset(assetPath);
            AssetDatabase.Refresh();
            _hasChanged = true;
            _selectedInstance = 0;
            ResetTempName();
        }

        private void OnInstanceSelected(int instanceIndex)
        {
            _selectedInstance = instanceIndex;

            if (TryGetSelectedInstance(out SubstanceMaterialInstanceSO target))
                EditorGUIUtility.PingObject(target);

            ResetTempName();
        }

        private bool TryRenameInstance(SubstanceMaterialInstanceSO instanceSO, string name)
        {
            if (!IsValidAndNoConflict(name))
                return false;

            instanceSO.Rename(name);
            return true;
        }

        #region Utilities

        private string GenerateNewInstanceName(SubstanceMaterialInstanceSO currentInstance)
        {
            var index = _importer._instancesCopy.Count;
            var newName = currentInstance.Name + $"_{index}";

            while (!IsValidAndNoConflict(newName))
                newName = currentInstance.Name + $"_{index++}";

            return newName;
        }

        private bool IsValidAndNoConflict(string name)
        {
            if (!IsValidName(name))
                return false;

            if (_importer._instancesCopy.Where(a => a != null).FirstOrDefault(a => a.Name == name) != null)
                return false;

            return true;
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
                return false;

            Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]");

            if (containsABadCharacter.IsMatch(name))
                return false;

            return true;
        }

        private bool TryGetCurrentGraph(out SubstanceGraph graph)
        {
            graph = null;

            if (!TryGetSelectedInstance(out SubstanceMaterialInstanceSO instance))
                return false;

            if (instance.Graphs == null || instance.Graphs[0] == null)
                return false;

            graph = instance.Graphs[0];

            return true;
        }

        private bool TryGetInstanceByIndex(int index, out SubstanceMaterialInstanceSO instance)
        {
            instance = null;

            if (_importer == null || _importer._instancesCopy == null || _importer._instancesCopy.Count == 0)
                return false;

            if (_importer._instancesCopy.Count <= index)
                return false;

            instance = _importer._instancesCopy[index];

            return instance != null;
        }

        private bool TryGetSelectedInstance(out SubstanceMaterialInstanceSO instance)
        {
            return TryGetInstanceByIndex(_selectedInstance, out instance);
        }

        private static void DrawUILine()
        {
            var rect = EditorGUILayout.BeginVertical();
            {
                Handles.color = Color.black;
                EditorGUILayout.Space(15);
                Handles.DrawLine(new Vector2(rect.x - 40, rect.y + (rect.height / 2)), new Vector2(rect.width + 20, rect.y + (rect.height / 2)));
                EditorGUILayout.Space(15);
            }
            EditorGUILayout.EndVertical();
        }

        private void ResetTempName()
        {
            if (TryGetSelectedInstance(out SubstanceMaterialInstanceSO material))
                _tempLabelName = material.Name;
        }

        private void EnsureRequiredTextures()
        {
            float c = (EditorGUIUtility.isProSkin) ? 0.35f : 0.65f;
            _backgroundImage = Globals.CreateColoredTexture(64, 64, new Color(c, c, c, 1));
            _textHightlightBackground = Globals.CreateColoredTexture(_instanceListPreviewSize, _instanceListPreviewSize, Color.gray);
        }

        private void EnsureRefreshedMaterials()
        {
            foreach (var instance in _importer._instancesCopy)
            {
                foreach (var graph in instance.Graphs)
                {
                    if (graph == null)
                        continue;

                    var material = graph.OutputMaterial;

                    if (material == null)
                        continue;

                    EditorUtility.SetDirty(material);
                }
            }

            AssetDatabase.Refresh();
        }

        #endregion Utilities
    }
}