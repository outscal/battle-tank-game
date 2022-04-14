using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Input.Description
{
    [System.Serializable]
    public class SubstanceInputDescNumericalInt3 : ISubstanceInputDescNumerical
    {
        [SerializeField]
        private Vector3Int _DefaultValue;

        public Vector3Int DefaultValue
        {
            get => _DefaultValue;
            set => _DefaultValue = value;
        }

        [SerializeField]
        private Vector3Int _MinValue;

        public Vector3Int MinValue
        {
            get => _MinValue;
            set => _MinValue = value;
        }

        [SerializeField]
        private Vector3Int _MaxValue;

        public Vector3Int MaxValue
        {
            get => _MaxValue;
            set => _MaxValue = value;
        }

        [SerializeField]
        private Vector3Int _SliderStep;

        public Vector3Int SliderStep
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
        private SubstanceInt3EnumOption[] _EnumValues;

        public SubstanceInt3EnumOption[] EnumValues
        {
            get => _EnumValues;
            set => _EnumValues = value;
        }
    }

    [System.Serializable]
    public class SubstanceInt3EnumOption
    {
        public Vector3Int Value;

        public string Label;
    }
}