using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Input.Description
{
    /// <summary>
    /// Numeric input description for input of type int.
    /// </summary>
    [System.Serializable]
    public class SubstanceInputDescNumericalInt : ISubstanceInputDescNumerical
    {
        [SerializeField]
        private int _DefaultValue;

        /// <summary>
        /// Default input value
        /// </summary>
        public int DefaultValue
        {
            get => _DefaultValue;
            set => _DefaultValue = value;
        }

        [SerializeField]
        private int _MinValue;

        /// <summary>
        /// Minimum value (UI hint only)
        /// </summary>
        public int MinValue
        {
            get => _MinValue;
            set => _MinValue = value;
        }

        [SerializeField]
        private int _MaxValue;

        /// <summary>
        /// Maximum value. Only relevant if widget is Slider (UI hint only)
        /// </summary>
        public int MaxValue
        {
            get => _MaxValue;
            set => _MaxValue = value;
        }

        [SerializeField]
        private float _SliderStep;

        /// <summary>
        /// Slider step size. Only relevant if widget is Slider (UI hint only).
        /// </summary>
        public float SliderStep
        {
            get => _SliderStep;
            set => _SliderStep = value;
        }

        [SerializeField]
        private bool _SliderClamp;

        /// <summary>
        /// True if the slider value is clamped. Only relevant if widget is Slider (UI hint only)
        /// </summary>
        public bool SliderClamp
        {
            get => _SliderClamp;
            set => _SliderClamp = value;
        }

        [SerializeField]
        private string _LabelFalse;

        /// <summary>
        /// If non-empty, the labels to use for False (unchecked) and True (checked) values. Only relevant if widget is Input_Togglebutton
        /// </summary>
        public string LabelFalse
        {
            get => _LabelFalse;
            set => _LabelFalse = value;
        }

        [SerializeField]
        private string _LabelTrue;

        public string LabelTrue
        {
            get => _LabelTrue;
            set => _LabelTrue = value;
        }

        [SerializeField]
        private int _EnumValueCount;

        /// <summary>
        /// Number of enum option for this value.
        /// </summary>
        public int EnumValueCount
        {
            get => _EnumValueCount;
            set => _EnumValueCount = value;
        }

        [SerializeField]
        private SubstanceIntEnumOption[] _EnumValues;

        /// <summary>
        /// Array of enum values for this property. Only relevant if widget is SBSARIO_WIDGET_COMBOBOX (UI hint only).
        /// </summary>
        public SubstanceIntEnumOption[] EnumValues
        {
            get => _EnumValues;
            set => _EnumValues = value;
        }
    }

    [System.Serializable]
    public class SubstanceIntEnumOption
    {
        public int Value;

        public string Label;
    }
}