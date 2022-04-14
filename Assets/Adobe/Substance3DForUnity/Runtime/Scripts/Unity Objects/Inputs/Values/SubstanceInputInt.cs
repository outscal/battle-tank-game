using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adobe.Substance.Input.Description;
using System;
using System.Runtime.InteropServices;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputInt : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private int _Index;

        [SerializeField]
        public int _Data;

        [SerializeField]
        private bool _isVisible;

        [SerializeField]
        private int _GraphID;

        [SerializeField]
        private SubstanceInputDescNumericalInt _NumericalDescription;

        public int Index => _Index;

        public int GraphID => _GraphID;

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Int;
        public bool IsNumeric => true;

        public int Data
        {
            get => _Data;
            set => _Data = value;
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }

        public SubstanceInputDescription Description
        {
            get => _Description;
            set => _Description = value;
        }

        [SerializeField]
        private bool _HasChanged;

        public bool HasChanged
        {
            get => _HasChanged;
            set => _HasChanged = value;
        }

        public ISubstanceInputDescNumerical NumericalDescription
        {
            get => _NumericalDescription;
        }

        internal SubstanceInputInt(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = data.mIntData0;
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputInt(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalInt
            {
                DefaultValue = desc.default_value.mIntData0,
                MaxValue = desc.max_value.mIntData0,
                MinValue = desc.min_value.mIntData0,
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                SliderStep = desc.sliderStep,
                EnumValueCount = desc.enumValueCount.ToInt32()
            };
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceIntEnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceIntEnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = options[i].value.mIntData0
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}