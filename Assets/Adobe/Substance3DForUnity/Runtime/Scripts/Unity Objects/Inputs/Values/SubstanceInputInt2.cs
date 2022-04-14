using System;
using UnityEngine;
using System.Runtime.InteropServices;
using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputInt2 : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private int _Index;

        [SerializeField]
        private int _GraphID;

        [SerializeField]
        private Vector2Int _Data;

        [SerializeField]
        private bool _isVisible;

        [SerializeField]
        private SubstanceInputDescNumericalInt2 _NumericalDescription;

        public int Index => _Index;

        public int GraphID => _GraphID;

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Int2;
        public bool IsNumeric => true;

        public SubstanceInputDescription Description
        {
            get => _Description;
            set => _Description = value;
        }

        public ISubstanceInputDescNumerical NumericalDescription
        {
            get => _NumericalDescription;
        }

        public Vector2Int Data
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

        internal SubstanceInputInt2(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = new Vector2Int(data.mIntData0, data.mIntData1);
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputInt2(_Data, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalInt2
            {
                DefaultValue = new Vector2Int(desc.default_value.mIntData0, desc.default_value.mIntData1),
                MaxValue = new Vector2Int(desc.max_value.mIntData0, desc.max_value.mIntData1),
                MinValue = new Vector2Int(desc.min_value.mIntData0, desc.min_value.mIntData1),
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                EnumValueCount = desc.enumValueCount.ToInt32()
            };
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceInt2EnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceInt2EnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = new Vector2Int(options[i].value.mIntData0, options[i].value.mIntData1)
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}