using System;
using UnityEngine;
using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputFont : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private int _Index;

        public int Index => _Index;

        [SerializeField]
        private int _GraphID;

        public int GraphID => _GraphID;

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Font;
        public SubstanceInputDescription Description { get => _Description; set => _Description = value; }
        public bool IsNumeric => false;

        [SerializeField]
        private Font _Data;

        public Font Data
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
        private bool _HasChanged;

        public bool HasChanged
        {
            get => _HasChanged;
            set => _HasChanged = value;
        }

        public ISubstanceInputDescNumerical NumericalDescription => null;

        internal SubstanceInputFont(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _Data = null;
            _GraphID = graphID;
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            return;
        }

        void ISubstanceInput.SetNumericDescription(NativeNumericInputDesc desc)
        {
            return;
        }

        void ISubstanceInput.SetEnumOptions(NativeEnumInputDesc[] options)
        {
            return;
        }
    }
}