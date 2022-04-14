using UnityEditor;
using UnityEngine;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    /// <summary>
    /// Base class for all property drawers for the substance input classes.
    /// </summary>
    internal abstract class SubstanceInputDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property == null)
                return;

            if (label is SubstanceInputGUIContent inputContent)
            {
                if (inputContent.Description.Type != SubstanceValueType.Int4)
                    OnGUI(position, property?.FindPropertyRelative("_Data"), inputContent);
                else
                    OnGUI(position, property, inputContent);
            }
            else
            {
                Debug.LogError($"GUIContent provided to a EditorGUILayout.PropertyField for a Substance Input must be of type {nameof(SubstanceInputGUIContent)}");
            }
        }

        protected virtual bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            if (content.Description.WidgetType == SubstanceWidgetType.NoWidget)
            {
                EditorGUI.LabelField(position, $"Hidden property.");
                return false;
            }

            EditorGUI.indentLevel++;
            EditorGUI.LabelField(position, $"Not supported. Value with widget {content.Description.WidgetType}");
            EditorGUI.indentLevel--;
            return false;
        }
    }
}