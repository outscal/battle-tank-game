using UnityEditor;
using UnityEngine;
using Adobe.Substance.Input;
using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Editor.PropertyDrawers
{
    [CustomPropertyDrawer(typeof(SubstanceInputInt))]
    internal class SubstanceInputIntDrawer : SubstanceInputDrawer
    {
        protected override bool OnGUI(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            if (content.Description.Label == "$randomseed")
                return DrawRandomSeedButton(position, valueProperty, content);

            switch (content.Description.WidgetType)
            {
                case SubstanceWidgetType.ToggleButton:
                    return DrawToggleButton(position, valueProperty, content as SubstanceNumericalInputGUIContent);

                case SubstanceWidgetType.Slider:
                    return DrawSlider(position, valueProperty, content as SubstanceNumericalInputGUIContent);

                case SubstanceWidgetType.ComboBox:
                    return DrawComboBox(position, valueProperty, content as SubstanceNumericalInputGUIContent);

                default:
                    return DrawDefault(position, valueProperty, content);
            }
        }

        /// <summary>
        /// Renders the int input as a toggle button.
        /// </summary>
        /// <param name="position">GUI position rect.</param>
        /// <param name="valueProperty">Value property.</param>
        /// <param name="content">GUI content.</param>
        /// <param name="description">Input description.</param>
        private bool DrawToggleButton(Rect position, SerializedProperty valueProperty, SubstanceNumericalInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var oldValue = valueProperty.intValue != 0;
            var newValue = EditorGUI.Toggle(position, label, oldValue);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.intValue = newValue ? 1 : 0;
            }

            EditorGUI.EndProperty();
            return result;
        }

        /// <summary>
        /// Renders the int input as a slider.
        /// </summary>
        /// <param name="position">GUI position rect.</param>
        /// <param name="valueProperty">Value property.</param>
        /// <param name="content">GUI content.</param>
        /// <param name="description">Input description.</param>
        private bool DrawSlider(Rect position, SerializedProperty valueProperty, SubstanceNumericalInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var numDescription = content.NumericalDescription as SubstanceInputDescNumericalInt;

            var maxValue = numDescription.MaxValue;
            var minValue = numDescription.MinValue;

            var oldValue = valueProperty.intValue;
            var newValue = EditorGUI.IntSlider(position, label, oldValue, minValue, maxValue);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.intValue = newValue;
            }

            EditorGUI.EndProperty();

            return result;
        }

        /// <summary>
        /// Renders the int input as combo box.
        /// </summary>
        /// <param name="position">GUI position rect.</param>
        /// <param name="valueProperty">Value property.</param>
        /// <param name="content">GUI content.</param>
        /// <param name="description">Input description.</param>
        private bool DrawComboBox(Rect position, SerializedProperty valueProperty, SubstanceNumericalInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var numDescription = content.NumericalDescription as SubstanceInputDescNumericalInt;

            var enumValues = numDescription.EnumValues;

            var guiContent = new GUIContent[enumValues.Length];
            var valueOptions = new int[enumValues.Length];

            for (int i = 0; i < guiContent.Length; i++)
            {
                var enumElement = enumValues[i];
                guiContent[i] = new GUIContent(enumElement.Label);
                valueOptions[i] = enumElement.Value;
            }

            var oldValue = valueProperty.intValue;
            var newValue = EditorGUI.IntPopup(position, label, oldValue, guiContent, valueOptions);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.intValue = newValue;
            }

            EditorGUI.EndProperty();
            return result;
        }

        /// <summary>
        /// Default input render.
        /// </summary>
        /// <param name="position">GUI position rect.</param>
        /// <param name="valueProperty">Value property.</param>
        /// <param name="content">GUI content.</param>
        private bool DrawDefault(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            var label = EditorGUI.BeginProperty(position, content, valueProperty);

            var oldValue = valueProperty.intValue;
            var newValue = EditorGUI.IntField(position, label, oldValue);

            if (oldValue != newValue)
            {
                result = true;
                valueProperty.intValue = newValue;
            }

            EditorGUI.EndProperty();

            return result;
        }

        private bool DrawRandomSeedButton(Rect position, SerializedProperty valueProperty, SubstanceInputGUIContent content)
        {
            bool result = false;

            int value = valueProperty.intValue;
            int minimum = 0;
            int maximum = 10000;

            int labelWidth = (int)EditorGUIUtility.labelWidth - 15;
            int fieldWidth = 50;

            content.text = "Random Seed";
            content.tooltip = "$randomseed: the overall random aspect of the texture";

            GUILayout.BeginHorizontal();
            {
                int buttonWidth = (int)EditorGUIUtility.currentViewWidth - labelWidth - fieldWidth - 60;

                EditorGUILayout.LabelField(content, GUILayout.Width(labelWidth));

                if (GUILayout.Button("Randomize", GUILayout.Width(buttonWidth)))
                {
                    value = UnityEngine.Random.Range(minimum, maximum);
                    valueProperty.intValue = value;
                    result = true;
                }

                EditorGUI.BeginChangeCheck();

                value = EditorGUILayout.IntField(value, GUILayout.Width(fieldWidth));

                if (EditorGUI.EndChangeCheck())
                {
                    value = (value < minimum) ? minimum : (value > maximum) ? maximum : value;
                    valueProperty.intValue = value;
                    result = true;
                }
            }

            GUILayout.EndHorizontal();
            return result;
        }
    }
}