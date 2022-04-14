using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adobe.Substance.Input.Description;
using System;
using System.Runtime.InteropServices;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputFloat4 : ISubstanceInput
    {
        [SerializeField]
        private int _Index;

        public int Index => _Index;

        [SerializeField]
        private int _GraphID;

        public int GraphID => _GraphID;
        public bool IsNumeric => true;

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Float4;

        [SerializeField]
        private Vector4 _Data;

        public Vector4 Data
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
        private SubstanceInputDescNumericalFloat4 _NumericalDescription;

        public ISubstanceInputDescNumerical NumericalDescription
        {
            get => _NumericalDescription;
        }

        internal SubstanceInputFloat4(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = new Vector4(data.mFloatData0, data.mFloatData1, data.mFloatData2, data.mFloatData3);
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputFloat4(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalFloat4
            {
                DefaultValue = new Vector4(desc.default_value.mFloatData0, desc.default_value.mFloatData1, desc.default_value.mFloatData2, desc.default_value.mFloatData3),
                MaxValue = new Vector4(desc.max_value.mFloatData0, desc.max_value.mFloatData1, desc.max_value.mFloatData2, desc.max_value.mFloatData3),
                MinValue = new Vector4(desc.min_value.mFloatData0, desc.min_value.mFloatData1, desc.min_value.mFloatData2, desc.min_value.mFloatData3),
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                SliderStep = desc.sliderStep,
                EnumValueCount = desc.enumValueCount.ToInt32()
            };

            return;
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceFloat4EnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceFloat4EnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = new Vector4(options[i].value.mFloatData0, options[i].value.mFloatData1, options[i].value.mFloatData2, options[i].value.mFloatData3)
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}