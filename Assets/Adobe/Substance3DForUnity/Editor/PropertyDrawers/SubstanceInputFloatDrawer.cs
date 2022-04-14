using UnityEditor;
using UnityEngine;
using Adobe.Substance.Input;
using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputFloat))]
    internal class SubstanceInputFloatDrawer : SubstanceInputDrawer
    {
        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            switch (content.Description.WidgetType)
            {
                case SubstanceWidgetType.Slider:
                    return DrawSlider(position, valueProperty, content as SubstanceNumericalInputGUIContent);

                default:
                    return DrawDefault(position, valueProperty, content);
            }
        }

        private bool DrawSlider(Rect position, SerializedProperty valueProperty, SubstanceNumericalInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var floatInputDesc = content.NumericalDescription as SubstanceInputDescNumericalFloat;

            var maxValue = floatInputDesc.MaxValue;
            var minValue = floatInputDesc.MinValue;
            var sliderClamp = maxValue != minValue;

            var oldValue = valueProperty.floatValue;

            var newValue = EditorGUI.Slider(position, label, oldValue, sliderClamp ? minValue : 0, sliderClamp ? maxValue : 50);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.floatValue = newValue;
            }

            EditorGUI.EndProperty();

            return result;
        }

        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var oldValue = valueProperty.floatValue;
            var newValue = EditorGUI.FloatField(position, label, oldValue);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.floatValue = newValue;
            }

            EditorGUI.EndProperty();

            return result;
        }
    }
}