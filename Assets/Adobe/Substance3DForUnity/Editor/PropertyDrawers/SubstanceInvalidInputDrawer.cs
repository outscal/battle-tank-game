using UnityEditor;
using UnityEngine;
using Adobe.Substance.Input;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInvalidInput))]
    internal class SubstanceInvalidInputDrawer : SubstanceInputDrawer
    {
        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            EditorGUI.LabelField(position, $"Unsupported parameter ({content.Description.WidgetType})");
            return false;
        }
    }
}