using UnityEditor;
using UnityEngine;
using Adobe.Substance.Input;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputFloat3))]
    internal class SubstanceInputFloat3Drawer : SubstanceInputDrawer
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
        /// Renders custome GUI for input float3 as color.
        /// </summary>
        /// <param name="position">GUI position rect.</param>
        /// <param name="valueProperty">Value property.</param>
        /// <param name="content">GUI content.</param>
        /// <param name="description">Description for the target input.</param>
        private bool DrawColorPicker(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);
            {
                var previewValue = valueProperty.vector3Value;

                var color = new Color(previewValue.x, previewValue.y, previewValue.z, 1);
                var newValue = EditorGUI.ColorField(position, label, color, false, false, false);

                if (color != newValue)
                {
                    valueProperty.vector3Value = new Vector4(newValue.r, newValue.g, newValue.b, newValue.a);
                    result = true;
                }
            }
            EditorGUI.EndProperty();

            return result;
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);
            {
                var previewValue = valueProperty.vector3Value;
                var newValue = EditorGUI.Vector3Field(position, label, previewValue);

                if (newValue != previewValue)
                {
                    valueProperty.vector3Value = newValue;
                    result = true;
                }
            }
            EditorGUI.EndProperty();
            return result;
        }
    }
}