using UnityEditor;
using Adobe.Substance.Input;
using UnityEngine;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputFloat2))]
    internal class SubstanceInputFloat2Drawer : SubstanceInputDrawer
    {
        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            switch (content.Description.WidgetType)
            {
                //TODO: Add edge cases here.
                default:
                    return DrawDefault(position, valueProperty, content);
            }
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            bool result = false;

            var previewValue = valueProperty.vector2Value;
            var newValue = EditorGUI.Vector2Field(position, label, previewValue);

            if (newValue != previewValue)
            {
                valueProperty.vector2Value = newValue;
                result = true;
            }

            EditorGUI.EndProperty();

            return result;
        }
    }
}