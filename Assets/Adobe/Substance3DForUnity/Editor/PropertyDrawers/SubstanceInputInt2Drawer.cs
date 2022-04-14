using UnityEditor;
using UnityEngine;
using Adobe.Substance.Input;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputInt2))]
    internal class SubstanceInputInt2Drawer : SubstanceInputDrawer
    {
        private static readonly string[] _resulutions = { "256", "512", "1024", "2048", "4096" };

        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            if (IsSizeAttribute(content))
            {
                return DrawResolutionSelection(position, valueProperty, content);
            }
            else
            {
                return DrawDefault(position, valueProperty, content);
            }
        }

        private bool DrawResolutionSelection(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            Vector2Int oldValue = valueProperty.vector2IntValue;
            var currentIndex = GetEnumIndex(oldValue);
            int newIndex = EditorGUI.Popup(position, "Output Resolution", currentIndex, _resulutions);

            if (currentIndex != newIndex)
            {
                Vector2Int newValue = GetValueFromIndex(newIndex);
                valueProperty.vector2IntValue = newValue;
                result = true;
            }

            EditorGUI.EndProperty();

            return result;
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            Vector2Int oldValue = valueProperty.vector2IntValue;
            var newValue = EditorGUI.Vector2IntField(position, content, oldValue);

            if (newValue != oldValue)
            {
                valueProperty.vector2IntValue = newValue;
                result = true;
            }

            EditorGUI.EndProperty();
            return result;
        }

        private bool IsSizeAttribute(GUIContent content)
        {
            return content.text == "$outputsize";
        }

        private int GetEnumIndex(Vector2Int data)
        {
            switch (data.x)
            {
                case 8: return 0;
                case 9: return 1;
                case 10: return 2;
                case 11: return 3;
                case 12: return 4;
                default:
                    return 0;
            }
        }

        private Vector2Int GetValueFromIndex(int index)
        {
            switch (index)
            {
                case 0: return new Vector2Int(8, 8);
                case 1: return new Vector2Int(9, 9);
                case 2: return new Vector2Int(10, 10);
                case 3: return new Vector2Int(11, 11);
                case 4: return new Vector2Int(12, 12);
                default:
                    return new Vector2Int(8, 8);
            }
        }
    }
}