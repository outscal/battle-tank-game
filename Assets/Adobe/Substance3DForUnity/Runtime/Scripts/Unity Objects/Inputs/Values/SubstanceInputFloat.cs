using Adobe.Substance.Input.Description;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Adobe.Substance.Input
{
    [Serializable]
    public class SubstanceInputFloat : ISubstanceInput
    {
        public bool IsNumeric => true;
        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Float;

        [SerializeField]
        private int _Index;

        public int Index => _Index;

        [SerializeField]
        private float _Data;

        public float Data
        {
            get => _Data;
            set => _Data = value;
        }

        [SerializeField]
        private bool _isVisible;

        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }

        [SerializeField]
        private SubstanceInputDescription _Description;

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

        [SerializeField]
        private SubstanceInputDescNumericalFloat _NumericalDescription;

        public ISubstanceInputDescNumerical NumericalDescription
        {
            get => _NumericalDescription;
        }

        [SerializeField]
        private int _GraphID;

        public int GraphID => _GraphID;

        internal SubstanceInputFloat(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = data.mFloatData0;
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputFloat(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalFloat
            {
                DefaultValue = desc.default_value.mFloatData0,
                MaxValue = desc.max_value.mFloatData0,
                MinValue = desc.min_value.mFloatData0,
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                SliderStep = desc.sliderStep,
                EnumValueCount = desc.enumValueCount.ToInt32()
            };

            return;
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceFloatEnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceFloatEnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = options[i].value.mFloatData0
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}