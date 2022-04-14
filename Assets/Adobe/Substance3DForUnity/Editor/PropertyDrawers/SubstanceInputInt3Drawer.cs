using UnityEditor;
using Adobe.Substance.Input;
using UnityEngine;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputInt3))]
    internal class SubstanceInputInt3Drawer : SubstanceInputDrawer
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
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var previewValue = valueProperty.vector3IntValue;
            var newValue = EditorGUI.Vector3IntField(position, label, previewValue);

            if (newValue != previewValue)
            {
                valueProperty.vector3IntValue = newValue;
                result = true;
            }

            EditorGUI.EndProperty();

            return result;
        }
    }
}