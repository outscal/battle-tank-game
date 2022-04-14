using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adobe.Substance.Input.Description;
using System;
using System.Runtime.InteropServices;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputFloat3 : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private int _Index;

        [SerializeField]
        public Vector3 _Data;

        [SerializeField]
        private bool _isVisible;

        [SerializeField]
        private SubstanceInputDescNumericalFloat3 _NumericalDescription;

        public int Index => _Index;

        [SerializeField]
        private int _GraphID;

        public int GraphID => _GraphID;

        public SubstanceValueType ValueType => SubstanceValueType.Float3;
        public bool IsNumeric => true;
        public bool IsValid => true;

        public Vector3 Data
        {
            get => _Data;
            set => _Data = value;
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = value;
        }

        [SerializeField]
        private bool _HasChanged;

        public bool HasChanged
        {
            get => _HasChanged;
            set => _HasChanged = value;
        }

        public SubstanceInputDescription Description
        {
            get => _Description;
            set => _Description = value;
        }

        public ISubstanceInputDescNumerical NumericalDescription
        {
            get => _NumericalDescription;
        }

        internal SubstanceInputFloat3(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = new Vector3(data.mFloatData0, data.mFloatData1, data.mFloatData2);
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputFloat3(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalFloat3
            {
                DefaultValue = new Vector3(desc.default_value.mFloatData0, desc.default_value.mFloatData1, desc.default_value.mFloatData2),
                MaxValue = new Vector3(desc.max_value.mFloatData0, desc.max_value.mFloatData1, desc.max_value.mFloatData2),
                MinValue = new Vector3(desc.min_value.mFloatData0, desc.min_value.mFloatData1, desc.min_value.mFloatData2),
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                SliderStep = desc.sliderStep,
                EnumValueCount = desc.enumValueCount.ToInt32()
            };

            return;
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceFloat3EnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceFloat3EnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = new Vector3(options[i].value.mFloatData0, options[i].value.mFloatData1, options[i].value.mFloatData2)
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}