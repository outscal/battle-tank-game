using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Input.Description
{
    /// <summary>
    /// Numeric input description for input of type int2.
    /// </summary>
    [System.Serializable]
    public class SubstanceInputDescNumericalInt2 : ISubstanceInputDescNumerical
    {
        [SerializeField]
        private Vector2Int _DefaultValue;

        /// <summary>
        /// Default input value
        /// </summary>
        public Vector2Int DefaultValue
        {
            get => _DefaultValue;
            set => _DefaultValue = value;
        }

        [SerializeField]
        private Vector2Int _MinValue;

        /// <summary>
        /// Minimum value (UI hint only)
        /// </summary>
        public Vector2Int MinValue
        {
            get => _MinValue;
            set => _MinValue = value;
        }

        [SerializeField]
        private Vector2Int _MaxValue;

        /// <summary>
        /// Maximum value. Only relevant if widget is Slider (UI hint only)
        /// </summary>
        public Vector2Int MaxValue
        {
            get => _MaxValue;
            set => _MaxValue = value;
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
        private SubstanceInt2EnumOption[] _EnumValues;

        /// <summary>
        /// Array of enum values for this property. Only relevant if widget is ComboBox (UI hint only).
        /// </summary>
        public SubstanceInt2EnumOption[] EnumValues
        {
            get => _EnumValues;
            set => _EnumValues = value;
        }
    }

    [System.Serializable]
    public class SubstanceInt2EnumOption
    {
        public Vector2Int Value;

        public string Label;
    }
}