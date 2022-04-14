using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adobe.Substance.Input.Description;
using System;
using System.Runtime.InteropServices;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputFloat2 : ISubstanceInput
    {
        public SubstanceValueType ValueType => SubstanceValueType.Float2;
        public bool IsNumeric => true;
        public bool IsValid => true;

        [SerializeField]
        private int _Index;

        public int Index => _Index;

        [SerializeField]
        private int _GraphID;

        public int GraphID => _GraphID;

        [SerializeField]
        private Vector2 _Data;

        public Vector2 Data
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
        private SubstanceInputDescNumericalFloat2 _NumericalDescription;

        public ISubstanceInputDescNumerical NumericalDescription
        {
            get => _NumericalDescription;
        }

        internal SubstanceInputFloat2(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = new Vector2(data.mFloatData0, data.mFloatData1);
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputFloat2(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalFloat2
            {
                DefaultValue = new Vector2(desc.default_value.mFloatData0, desc.default_value.mFloatData1),
                MaxValue = new Vector2(desc.max_value.mFloatData0, desc.max_value.mFloatData1),
                MinValue = new Vector2(desc.min_value.mFloatData0, desc.min_value.mFloatData1),
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                SliderStep = desc.sliderStep,
                EnumValueCount = desc.enumValueCount.ToInt32()
            };

            return;
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceFloat2EnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceFloat2EnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = new Vector2(options[i].value.mFloatData0, options[i].value.mFloatData1)
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}