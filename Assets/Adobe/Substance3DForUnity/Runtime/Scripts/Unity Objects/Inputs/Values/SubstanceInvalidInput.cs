using System;
using UnityEngine;
using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInvalidInput : ISubstanceInput
    {
        [SerializeField]
        private SubstanceInputDescription _Description;

        [SerializeField]
        private int _Index;

        [SerializeField]
        private int _GraphID;

        [SerializeField]
        private bool _isVisible;

        public int Index => _Index;

        public int GraphID => _GraphID;

        public bool IsValid => false;
        public SubstanceValueType ValueType => _Description.Type;
        public SubstanceInputDescription Description { get => _Description; set => _Description = value; }
        public bool IsNumeric => false;

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

        public SubstanceInvalidInput(int index, int graphID)
        {
            _Index = index;
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