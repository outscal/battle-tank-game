using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adobe.Substance.Input.Description;
using System;
using System.Runtime.InteropServices;

namespace Adobe.Substance.Input
{
    [Serializable]
    public class SubstanceInputInt4 : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private SubstanceInputDescNumericalInt4 _NumericalDescription;

        [SerializeField]
        private int _Index;

        [SerializeField]
        private int _GraphID;

        [SerializeField]
        public int _Data0;

        [SerializeField]
        public int _Data1;

        [SerializeField]
        public int _Data2;

        [SerializeField]
        public int _Data3;

        [SerializeField]
        private bool _isVisible;

        public int Index => _Index;

        public int GraphID => _GraphID;

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Int4;
        public SubstanceInputDescription Description { get => _Description; set => _Description = value; }
        public bool IsNumeric => true;
        public ISubstanceInputDescNumerical NumericalDescription => _NumericalDescription;

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

        internal SubstanceInputInt4(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data0 = data.mIntData0;
            _Data1 = data.mIntData1;
            _Data2 = data.mIntData2;
            _Data3 = data.mIntData3;
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputInt4(_Data0, _Data1, _Data2, _Data3, _Index, _GraphID);
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            _NumericalDescription = new SubstanceInputDescNumericalInt4
            {
                DefaultValue = new int[] { desc.default_value.mIntData0, desc.default_value.mIntData1, desc.default_value.mIntData2, desc.default_value.mIntData3 },
                MaxValue = new int[] { desc.max_value.mIntData0, desc.max_value.mIntData1, desc.max_value.mIntData2, desc.max_value.mIntData3 },
                MinValue = new int[] { desc.min_value.mIntData0, desc.min_value.mIntData1, desc.min_value.mIntData2, desc.min_value.mIntData3 },
                SliderClamp = Convert.ToBoolean(desc.sliderClamp.ToInt32()),
                EnumValueCount = desc.enumValueCount.ToInt32()
            };
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            _NumericalDescription.EnumValues = new SubstanceInt4EnumOption[options.Length];

            for (int i = 0; i < _NumericalDescription.EnumValues.Length; i++)
            {
                var option = new SubstanceInt4EnumOption
                {
                    Label = Marshal.PtrToStringAnsi(options[i].label),
                    Value = new int[] { options[i].value.mIntData0, options[i].value.mIntData1, options[i].value.mIntData2, options[i].value.mIntData3 }
                };

                _NumericalDescription.EnumValues[i] = option;
            }

            return;
        }
    }
}