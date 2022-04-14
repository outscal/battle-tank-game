using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Input.Description
{
    public class SubstanceInputDescNumericalInt4 : ISubstanceInputDescNumerical
    {
        [SerializeField]
        private int[] _DefaultValue;

        public int[] DefaultValue
        {
            get => _DefaultValue;
            set => _DefaultValue = value;
        }

        [SerializeField]
        private int[] _MinValue;

        public int[] MinValue
        {
            get => _MinValue;
            set => _MinValue = value;
        }

        [SerializeField]
        private int[] _MaxValue;

        public int[] MaxValue
        {
            get => _MaxValue;
            set => _MaxValue = value;
        }

        [SerializeField]
        private int[] _SliderStep;

        public int[] SliderStep
        {
            get => _SliderStep;
            set => _SliderStep = value;
        }

        [SerializeField]
        private bool _SliderClamp;

        public bool SliderClamp
        {
            get => _SliderClamp;
            set => _SliderClamp = value;
        }

        [SerializeField]
        private int _EnumValueCount;

        public int EnumValueCount
        {
            get => _EnumValueCount;
            set => _EnumValueCount = value;
        }

        [SerializeField]
        private SubstanceInt4EnumOption[] _EnumValues;

        public SubstanceInt4EnumOption[] EnumValues
        {
            get => _EnumValues;
            set => _EnumValues = value;
        }
    }

    [System.Serializable]
    public class SubstanceInt4EnumOption
    {
        public int[] Value;

        public string Label;
    }
}