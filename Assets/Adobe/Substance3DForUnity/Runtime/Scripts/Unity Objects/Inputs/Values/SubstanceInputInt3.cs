using UnityEngine;
using System;
using System.Runtime.InteropServices;
using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputInt3 : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private int _Index;

        [SerializeField]
        private int _GraphID;

        [SerializeField]
        private Vector3Int _Data;

        [SerializeField]
        private bool _isVisible;

        [SerializeField]
        private SubstanceInputDescNumericalInt3 _NumericalDescription;

        public int Index => _Index;

        public int GraphID => _GraphID;

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Int3;
        public bool IsNumeric => true;

        public Vector3Int Data
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

        internal SubstanceInputInt3(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _Data = new Vector3Int(data.mIntData0, data.mIntData1, data.mIntData2);
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputInt3(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalInt3
            {
                DefaultValue = new Vector3Int(desc.default_value.mIntData0, desc.default_value.mIntData1, desc.default_value.mIntData2),
                MaxValue = new Vector3Int(desc.max_value.mIntData0, desc.max_value.mIntData1, desc.max_value.mIntData2),
                MinValue = new Vector3Int(desc.min_value.mIntData0, desc.min_value.mIntData1, desc.min_value.mIntData2),
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                EnumValueCount = desc.enumValueCount.ToInt32()
            };
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceInt3EnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceInt3EnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = new Vector3Int(options[i].value.mIntData0, options[i].value.mIntData1, options[i].value.mIntData2)
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}