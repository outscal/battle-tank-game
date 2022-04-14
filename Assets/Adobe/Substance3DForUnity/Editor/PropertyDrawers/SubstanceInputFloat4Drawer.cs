using UnityEditor;
using UnityEngine;
using Adobe.Substance.Input;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputFloat4))]
    internal class SubstanceInputFloat4Drawer : SubstanceInputDrawer
    {
        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            switch (content.Description.WidgetType)
            {
                case SubstanceWidgetType.Color:
                    return DrawColorPicker(position, valueProperty, content);

                default:
                    return DrawDefault(position, valueProperty, content);
            }
        }

        /// <summary>
        /// Renders custome GUI for input float4 as color.
        /// </summary>
        /// <param name="position">GUI position rect.</param>
        /// <param name="valueProperty">Value property.</param>
        /// <param name="content">GUI content.</param>
        /// <param name="description">Description for the target input.</param>
        private bool DrawColorPicker(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var previewValue = valueProperty.vector4Value;

            var color = new Color(previewValue.x, previewValue.y, previewValue.z, previewValue.w);
            var newValue = EditorGUI.ColorField(position, label, color);

            if (color != newValue)
            {
                result = true;
                valueProperty.vector4Value = new Vector4(newValue.r, newValue.g, newValue.b, newValue.a);
            }

            EditorGUI.EndProperty();

            return result;
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var oldValue = valueProperty.vector4Value;
            var newValue = EditorGUI.Vector4Field(position, label, oldValue);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.vector4Value = newValue;
            }

            EditorGUI.EndProperty();

            return result;
        }
    }
}