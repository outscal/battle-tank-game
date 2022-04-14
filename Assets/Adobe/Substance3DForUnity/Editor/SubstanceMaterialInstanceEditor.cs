using System;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    [CustomEditor(typeof(SubstanceMaterialInstanceSO))]
    public class SubstanceMaterialInstanceEditor : UnityEditor.Editor
    {
        private GraphInputsGroupingHelper _inputGroupingHelper;

        private GraphOutputAlphaChannelsHelper _outputChannelsHelper;

        private bool _propertiesChanged = false;

        private bool _showOutput = true;

        private bool _showExportPresentationHandler = false;

        private SubstanceMaterialInstanceSO _target = null;

        // Scrollview handling:
        private Rect lastRect;

        private Texture2D _backgroundImage;

        private MaterialEditor _materialPreviewEditor;

        private Vector2 _textureOutputScrollView;

        public void OnEnable()
        {
            if (!IsSerializedObjectReady())
                return;

            _target = serializedObject.targetObject as SubstanceMaterialInstanceSO;
            _textureOutputScrollView = Vector2.zero;
            _propertiesChanged = false;
            _inputGroupingHelper = new GraphInputsGroupingHelper(_target.Graphs, serializedObject);
            _outputChannelsHelper = new GraphOutputAlphaChannelsHelper(_target.Graphs[0]);

            float c = (EditorGUIUtility.isProSkin) ? 0.35f : 0.65f;
            _backgroundImage = Globals.CreateColoredTexture(16, 16, new Color(c, c, c, 1));

            var material = _target.Graphs[0].OutputMaterial;

            if (material != null)
                _materialPreviewEditor = MaterialEditor.CreateEditor(material) as MaterialEditor;

            EditorApplication.projectWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
        }

        public void OnDisable()
        {
            SaveEditorChanges();

            if (_materialPreviewEditor != null)
            {
                _materialPreviewEditor.OnDisable();
                _materialPreviewEditor = null;
            }

            EditorApplication.projectWindowItemOnGUI -= OnHierarchyWindowItemOnGUI;
        }

        public void SaveEditorChanges()
        {
            if (_propertiesChanged)
            {
                SaveTGAFiles();
                UpdateGraphMaterialLabel();
                AssetDatabase.Refresh();
            }

            _propertiesChanged = false;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var graphsList = serializedObject.FindProperty("Graphs");
            SerializedProperty rootGraph = graphsList.GetArrayElementAtIndex(0);

            if (rootGraph != null)
                _propertiesChanged |= DrawGraph(rootGraph);

            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Callback for GUI events to block substance files from been duplicated.
        /// </summary>
        /// <param name="guid">Asset guid.</param>
        /// <param name="rt">GUI rect.</param>
        protected static void OnHierarchyWindowItemOnGUI(string guid, Rect rt)
        {
            var currentEvent = Event.current;

            if ("Duplicate" == currentEvent.commandName && currentEvent.type == EventType.ExecuteCommand)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var instanceObject = AssetDatabase.LoadAssetAtPath<SubstanceMaterialInstanceSO>(assetPath);

                if (instanceObject != null)
                {
                    Debug.LogWarning("Substance graph can not be manually duplicated.");
                    currentEvent.Use();
                }
            }
        }

        #region Material Preview

        public override bool HasPreviewGUI()
        {
            return (_materialPreviewEditor != null) ? true : false;
        }

        public override GUIContent GetPreviewTitle()
        {
            return new GUIContent("Material", null, "");
        }

        public override void OnPreviewSettings()
        {
            if (_materialPreviewEditor)
                _materialPreviewEditor.OnPreviewSettings();
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            if (_materialPreviewEditor)
                _materialPreviewEditor.OnPreviewGUI(r, background);
        }

        #endregion Material Preview

        #region Draw

        private bool DrawGraph(SerializedProperty graph)
        {
            GUIContent content = new GUIContent();

            SerializedProperty generateAllOutputsProperty = graph.FindPropertyRelative("GenerateAllOutputs");
            SerializedProperty generateAllMipmapsProperty = graph.FindPropertyRelative("GenerateAllMipmaps");
            SerializedProperty runtimeOnlyProperty = graph.FindPropertyRelative("IsRuntimeOnly");

            bool generationSettingsChanged = DrawTextureGenerationSettings(generateAllOutputsProperty, generateAllMipmapsProperty, runtimeOnlyProperty, content);

            if (generationSettingsChanged)
            {
                var renderTextureProperty = graph.FindPropertyRelative("OutputRemaped");
                renderTextureProperty.boolValue = true;
            }

            GUILayout.Space(8);

            bool valuesChanged = DrawInputGroupsList();

            if (valuesChanged)
            {
                var renderTextureProperty = graph.FindPropertyRelative("RenderTextures");
                renderTextureProperty.boolValue = true;
            }

            DrawPresentExport(graph, _target.Graphs[0], content);

            EditorGUILayout.Space();

            _showOutput = EditorGUILayout.Foldout(_showOutput, "Generated textures");

            if (_showOutput)
            {
                var graphOutputs = graph.FindPropertyRelative("Output");
                bool outputRemaped = DrawGeneratedTextures(graphOutputs, generateAllOutputsProperty.boolValue, content);

                if (outputRemaped)
                {
                    var outputRemapedProperty = graph.FindPropertyRelative("OutputRemaped");
                    outputRemapedProperty.boolValue = true;
                    valuesChanged = true;
                }
            }

            return valuesChanged;
        }

        #region Texture Generation Settings

        private bool DrawTextureGenerationSettings(SerializedProperty generateAllOutputsProperty, SerializedProperty generateAllMipmapsProperty, SerializedProperty runtimeOnlyProperty, GUIContent content)
        {
            bool changed = false;

            GUILayout.Space(4);

            var boxWidth = EditorGUIUtility.currentViewWidth;
            var boxHeight = (3 * EditorGUIUtility.singleLineHeight) + 16;
            var padding = 16;

            var boxRect = DrawHighlightBox(boxWidth, boxHeight, padding);

            changed |= DrawGenerateAllOutputs(generateAllOutputsProperty, content);
            changed |= DrawGenerateAllMipmaps(generateAllMipmapsProperty, content);
            changed |= DrawRuntimeOnlyToggle(runtimeOnlyProperty, content);

            return changed;
        }

        private bool DrawGenerateAllOutputs(SerializedProperty generateAllOutputsProperty, GUIContent content)
        {
            content.text = "Generate All Outputs";
            content.tooltip = "Force the generation of all Substance outputs";

            EditorGUI.BeginChangeCheck();
            generateAllOutputsProperty.boolValue = EditorGUILayout.Toggle(content, generateAllOutputsProperty.boolValue);
            return EditorGUI.EndChangeCheck();
        }

        private bool DrawGenerateAllMipmaps(SerializedProperty generateAllMipmapsProperty, GUIContent content)
        {
            content.text = "Generate Mip Maps";
            content.tooltip = "Enable MipMaps when generating textures";

            EditorGUI.BeginChangeCheck();
            generateAllMipmapsProperty.boolValue = EditorGUILayout.Toggle(content, generateAllMipmapsProperty.boolValue);
            return EditorGUI.EndChangeCheck();
        }

        private bool DrawRuntimeOnlyToggle(SerializedProperty runtimeOnlyProperty, GUIContent content)
        {
            content.text = "Runtime only";
            content.tooltip = "If checked this instance will not generate TGA texture files";

            EditorGUI.BeginChangeCheck();
            runtimeOnlyProperty.boolValue = EditorGUILayout.Toggle(content, runtimeOnlyProperty.boolValue);
            return EditorGUI.EndChangeCheck();
        }

        #endregion Texture Generation Settings

        #region Input draw

        private bool DrawInputGroupsList()
        {
            bool valueChanged = false;

            EditorGUILayout.Space();
            valueChanged |= DrawInputHeader(_inputGroupingHelper.GrouplessInputs);
            EditorGUILayout.Space();

            foreach (var groupInfo in _inputGroupingHelper.InputGroups)
            {
                valueChanged |= DrawInputGroup(groupInfo);
                EditorGUILayout.Space();
            }

            return valueChanged;
        }

        private bool DrawInputHeader(SubstanceInputGroupCachedInfo headerInfo)
        {
            var indexArray = headerInfo.Inputs;

            bool valueChanged = false;

            EditorGUI.BeginChangeCheck();

            for (int i = 0; i < indexArray.Count; i++)
            {
                var property = indexArray[i].InputProperty;
                var guiContent = indexArray[i].GUIContent;
                var isVisible = indexArray[i].IsVisible;

                if (isVisible)
                    EditorGUILayout.PropertyField(property, guiContent);
            }

            valueChanged |= EditorGUI.EndChangeCheck();

            return valueChanged;
        }

        private bool DrawInputGroup(SubstanceInputGroupCachedInfo groupInfo)
        {
            var groupName = groupInfo.Name;
            var indexArray = groupInfo.Inputs;

            groupInfo.ShowGroup = EditorGUILayout.Foldout(groupInfo.ShowGroup, groupName);

            if (!groupInfo.ShowGroup)
                return false;

            EditorGUI.BeginChangeCheck();

            for (int i = 0; i < indexArray.Count; i++)
            {
                EditorGUI.indentLevel++;

                var property = indexArray[i].InputProperty;
                var guiContent = indexArray[i].GUIContent;
                var isVisible = indexArray[i].IsVisible;

                if (isVisible)
                    EditorGUILayout.PropertyField(property, guiContent);

                EditorGUI.indentLevel--;
            }

            return EditorGUI.EndChangeCheck();
        }

        #endregion Input draw

        #region Output draw

        private bool DrawGeneratedTextures(SerializedProperty outputList, bool generateAllTextures, GUIContent content)
        {
            bool valueChanged = false;
            EditorGUILayout.Space(4);

            using (var scrollViewScope = new EditorGUILayout.ScrollViewScope(_textureOutputScrollView, false, false))
            {
                scrollViewScope.handleScrollWheel = false;
                _textureOutputScrollView = scrollViewScope.scrollPosition;

                EditorGUILayout.BeginHorizontal();
                {
                    var outputsCount = outputList.arraySize;

                    for (int i = 0; i < outputsCount; i++)
                    {
                        var inputProperty = outputList.GetArrayElementAtIndex(i);
                        var isStandard = inputProperty.FindPropertyRelative("IsStandardOutput").boolValue;

                        if (generateAllTextures || isStandard)
                            valueChanged |= DrawOutputTexture(inputProperty, content);
                    }
                }
                EditorGUILayout.EndHorizontal();
            }

            return valueChanged;
        }

        private bool DrawOutputTexture(SerializedProperty output, GUIContent content)
        {
            var valueChanged = false;

            EditorGUILayout.BeginVertical(GUILayout.Width(120));
            {
                var texture = output.FindPropertyRelative("OutputTexture").objectReferenceValue as Texture2D;
                var label = output.FindPropertyRelative("Description.Channel").stringValue;
                var sRGB = output.FindPropertyRelative("sRGB");
                var alpha = output.FindPropertyRelative("AlphaChannel");
                var inverAlpha = output.FindPropertyRelative("InvertAssignedAlpha");
                var isAlphaAssignable = output.FindPropertyRelative("IsAlphaAssignable").boolValue;

                //Draw texture preview.
                if (texture != null)
                {
                    if (texture != null)
                    {
                        content.text = null;
                        content.image = AssetPreview.GetAssetPreview(texture);
                        content.tooltip = texture.name;

                        if (GUILayout.Button(content, //style,
                                         GUILayout.Width(70),
                                         GUILayout.Height(70)))
                        {
                            // Highlight object in project browser:
                            EditorGUIUtility.PingObject(texture);
                        }
                    }
                }

                GUILayout.Label(label);

                var oldsRGB = sRGB.boolValue;
                var newsRGB = GUILayout.Toggle(oldsRGB, "sRGB");

                if (newsRGB != oldsRGB)
                {
                    sRGB.boolValue = newsRGB;
                    valueChanged = true;
                }

                //Draw alpha remapping.
                EditorGUILayout.BeginHorizontal(GUILayout.Width(80), GUILayout.Height(EditorGUIUtility.singleLineHeight));
                {
                    if (isAlphaAssignable)
                    {
                        var option = _outputChannelsHelper.GetAlphaChannels(label);
                        var index = 0;

                        if (!string.IsNullOrEmpty(alpha.stringValue))
                            index = Array.IndexOf(option, alpha.stringValue);

                        EditorGUILayout.LabelField("A", GUILayout.Width(10));

                        var newIndex = EditorGUILayout.Popup(index, option, GUILayout.Width(70));

                        if (newIndex != index)
                        {
                            alpha.stringValue = newIndex != 0 ? option[newIndex] : string.Empty;
                            valueChanged = true;
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();

                //Draw inver alpha.
                EditorGUILayout.BeginHorizontal(GUILayout.Width(80), GUILayout.Height(EditorGUIUtility.singleLineHeight));
                {
                    if (!string.IsNullOrEmpty(alpha.stringValue))
                    {
                        var oldValue = inverAlpha.boolValue;
                        var newValue = GUILayout.Toggle(oldValue, "Invert alpha");

                        if (newValue != oldValue)
                        {
                            inverAlpha.boolValue = newValue;
                            valueChanged = true;
                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();

            return valueChanged;
        }

        #endregion Output draw

        #region Presets draw

        private void DrawPresentExport(SerializedProperty graphProp, SubstanceGraph graph, GUIContent content)
        {
            int labelWidth = (int)EditorGUIUtility.labelWidth - 15;

            _showExportPresentationHandler = EditorGUILayout.Foldout(_showExportPresentationHandler, "Preset Handling", true);

            if (_showExportPresentationHandler)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(" ", GUILayout.Width(labelWidth)); // Used to position the next button

                    content.text = "Export Preset...";
                    content.tooltip = "Save Preset";

                    if (GUILayout.Button(content))
                        HandleExportPresets(graph);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(" ", GUILayout.Width(labelWidth)); // Used to position the next button

                    content.text = "Import Preset...";
                    content.tooltip = "Fetch Preset";

                    if (GUILayout.Button(content))
                        HandleImportPresets(graph);
                }
                EditorGUILayout.EndHorizontal();

                GUILayout.Space(6);

                EditorGUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(" ", GUILayout.Width(labelWidth)); // Used to position the next button

                    content.text = "Reset Preset to Default";
                    content.tooltip = "Restore input defaults";

                    if (GUILayout.Button(content))
                        HandleResetPresets(graph);
                }
                EditorGUILayout.EndHorizontal();
            }
        }

        private void HandleExportPresets(SubstanceGraph graph)
        {
            string savePath = EditorUtility.SaveFilePanel("Save Preset as...", graph.FilePath, graph.GetAssetFileName(), "sbsprs");

            if (savePath != "")
            {
                string savePreset = "<sbspresets count=\"1\" formatversion=\"1.1\">\n "; //formatting line needed by other integrations
                savePreset += SubstanceEditorEngine.instance.ExportGraphPresetXML(_target, graph.Index);
                savePreset += "</sbspresets>";
                File.WriteAllText(savePath, savePreset);
            }
        }

        private void HandleImportPresets(SubstanceGraph graph)
        {
            string loadPath = EditorUtility.OpenFilePanel("Select Preset", graph.FilePath, "sbsprs");

            if (loadPath != "")
            {
                string presetFile = System.IO.File.ReadAllText(loadPath);

                int startIndex = presetFile.IndexOf("<sbspreset ");
                int endIndex = presetFile.IndexOf("sbspreset>") + 10;
                var presetXML = presetFile.Substring(startIndex, endIndex - startIndex);

                SubstanceEditorEngine.instance.LoadPresetsToGraph(_target, graph.Index, presetXML);
            }
        }

        private void HandleResetPresets(SubstanceGraph graph)
        {
            SubstanceEditorEngine.instance.LoadPresetsToGraph(_target, graph.Index, graph.DefaultPreset);
        }

        #endregion Presets draw

        #region Thumbnail preview

        public override Texture2D RenderStaticPreview(string assetPath, UnityEngine.Object[] subAssets, int width, int height)
        {
            if (_target.Graphs[0].HasThumbnail)
                return _target.Graphs[0].GetThumbnailTexture();

            var icon = UnityPackageInfo.GetSubstanceIcon(width, height);

            if (icon != null)
            {
                Texture2D tex = new Texture2D(width, height);
                EditorUtility.CopySerialized(icon, tex);
                return tex;
            }

            return base.RenderStaticPreview(assetPath, subAssets, width, height);
        }

        #endregion Thumbnail preview

        #endregion Draw

        #region Scene Drag

        public void OnSceneDrag(SceneView sceneView, int index)
        {
            Event evt = Event.current;

            if (evt.type == EventType.Repaint)
                return;

            var materialIndex = -1;
            var go = HandleUtility.PickGameObject(evt.mousePosition, out materialIndex);

            var graph = _target.Graphs[0];

            if (graph.OutputMaterial != null)
            {
                if (go && go.GetComponent<Renderer>())
                {
                    HandleRenderer(go.GetComponent<Renderer>(), materialIndex, _target.Graphs[0].OutputMaterial, evt.type, evt.alt);

                    if (graph.IsRuntimeOnly)
                    {
                        var runtimeComponent = go.GetComponent<Runtime.SubstanceRuntimeMaterial>();

                        if (runtimeComponent == null)
                            runtimeComponent = go.AddComponent<Runtime.SubstanceRuntimeMaterial>();

                        runtimeComponent.AttachMaterial(_target);
                    }
                }
            }
        }

        internal static void HandleRenderer(Renderer r, int materialIndex, Material dragMaterial, EventType eventType, bool alt)
        {
            var applyMaterial = false;
            switch (eventType)
            {
                case EventType.DragUpdated:
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;
                    applyMaterial = true;
                    break;

                case EventType.DragPerform:
                    DragAndDrop.AcceptDrag();
                    applyMaterial = true;
                    break;
            }
            if (applyMaterial)
            {
                var materials = r.sharedMaterials;

                bool isValidMaterialIndex = (materialIndex >= 0 && materialIndex < r.sharedMaterials.Length);
                if (!alt && isValidMaterialIndex)
                {
                    materials[materialIndex] = dragMaterial;
                }
                else
                {
                    for (int q = 0; q < materials.Length; ++q)
                        materials[q] = dragMaterial;
                }

                r.sharedMaterials = materials;
            }
        }

        #endregion Scene Drag

        #region Utilities

        private void SaveTGAFiles()
        {
            foreach (var graph in _target.Graphs)
            {
                if (graph.IsRuntimeOnly)
                    continue;

                foreach (var output in graph.Output)
                {
                    if (output.OutputTexture == null)
                        continue;

                    var targetTexture = output.OutputTexture;
                    var assetPath = AssetDatabase.GetAssetPath(targetTexture);

                    if (targetTexture != null)
                    {
                        if (!targetTexture.isReadable)
                            targetTexture = TextureUtils.SetReadableFlag(targetTexture, true);

                        if (targetTexture.format.IsCompressed())
                            targetTexture = TextureUtils.MakeUncompressed(targetTexture);

                        targetTexture = TextureUtils.EnforceMaxResolution(targetTexture);

                        var bytes = targetTexture.EncodeToTGA();
                        File.WriteAllBytes(assetPath, bytes);
                    }
                }
            }
        }

        private Rect DrawHighlightBox(float width, float height, float xPadding)
        {
            float bx, by, bw, bh;

            bx = xPadding;
            by = GetPosition();
            bw = width - xPadding;
            bh = height;

            var boxRect = new Rect(bx, by, bw, bh);

            var backgroundStyle = new GUIStyle();
            backgroundStyle.normal.background = _backgroundImage;
            GUI.Box(boxRect, GUIContent.none, backgroundStyle);
            return boxRect;
        }

        private int GetPosition()
        {
            Rect rect = GUILayoutUtility.GetLastRect();

            if ((rect.x != 0) || (rect.y != 0))
                lastRect = rect;

            return (int)lastRect.y;
        }

        /// This is a workaround a bug in the Unity asset database for generating materials previews.
        /// It basically generated a previews image whenever a property changes in the material, but it is now considering changes in the
        /// textures assign to the material itself. By adding a random label we ensure that the asset preview image will be updated.
        private void UpdateGraphMaterialLabel()
        {
            const string tagPrefix = "sb_";

            foreach (var graph in _target.Graphs)
            {
                var material = graph.OutputMaterial;

                if (material != null)
                {
                    var labels = AssetDatabase.GetLabels(material);
                    var newLabels = labels.Where(a => !a.Contains(tagPrefix)).ToList();
                    newLabels.Add($"{tagPrefix}{Guid.NewGuid().ToString("N")}");
                    AssetDatabase.SetLabels(material, newLabels.ToArray());
                }
            }
        }

        #endregion Utilities

        /// Work around Unity SerializedObjectNotCreatableException during script compilation.
        private bool IsSerializedObjectReady()
        {
            try
            {
                if (serializedObject.targetObject == null)
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}