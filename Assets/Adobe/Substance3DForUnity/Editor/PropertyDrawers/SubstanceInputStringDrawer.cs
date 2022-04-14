using UnityEditor;
using Adobe.Substance.Input;
using UnityEngine;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputString))]
    internal class SubstanceInputStringDrawer : SubstanceInputDrawer
    {
        //Ratio label to TextArea.
        private const float ratio = 2.25f;

        // How many lines should the text input have.
        private const int inputLinesCount = 3;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * inputLinesCount;
        }

        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            switch (content.Description.WidgetType)
            {
                default:
                    return DrawDefault(position, valueProperty, content);
            }
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = true;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            int labelSize = (int)(position.width / ratio);

            var labelRect = position;
            labelRect.width = labelSize;

            EditorGUI.LabelField(labelRect, label);

            var previewValue = valueProperty.stringValue;
            var textAreaRect = position;
            textAreaRect.width = position.width - labelSize;
            textAreaRect.x = labelSize;
            var newValue = EditorGUI.TextArea(textAreaRect, previewValue);

            if (newValue != previewValue)
            {
                result = true;
                valueProperty.stringValue = newValue;
            }

            EditorGUI.EndProperty();
            return result;
        }
    }
}