using UnityEditor;
using Adobe.Substance.Input;
using UnityEngine;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputInt4))]
    internal class SubstanceInputInt4Drawer : SubstanceInputDrawer
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

            var value0 = valueProperty?.FindPropertyRelative("_Data0");
            var value1 = valueProperty?.FindPropertyRelative("_Data1");
            var value2 = valueProperty?.FindPropertyRelative("_Data2");
            var value3 = valueProperty?.FindPropertyRelative("_Data3");

            var previewValue0 = value0.intValue;
            var previewValue1 = value1.intValue;
            var previewValue2 = value2.intValue;
            var previewValue3 = value3.intValue;

            var newValue0 = EditorGUI.IntField(position, label, previewValue0);
            var newValue1 = EditorGUI.IntField(position, label, previewValue0);
            var newValue2 = EditorGUI.IntField(position, label, previewValue0);
            var newValue3 = EditorGUI.IntField(position, label, previewValue0);

            if (newValue0 != previewValue0)
            {
                value0.intValue = newValue0;
                result = true;
            }

            if (newValue1 != previewValue1)
            {
                value1.intValue = newValue1;
                result = true;
            }

            if (newValue2 != previewValue2)
            {
                value2.intValue = newValue2;
                result = true;
            }

            if (newValue3 != previewValue3)
            {
                value3.intValue = newValue3;
                result = true;
            }

            EditorGUI.EndProperty();
            return result;
        }
    }
}