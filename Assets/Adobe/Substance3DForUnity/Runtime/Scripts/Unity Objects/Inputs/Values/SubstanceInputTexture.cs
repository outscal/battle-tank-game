using System;
using UnityEngine;
using Adobe.Substance.Input.Description;
using System.Runtime.InteropServices;

namespace Adobe.Substance.Input
{
    [System.Serializable]
    public class SubstanceInputTexture : ISubstanceInput
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

        public bool IsValid => true;
        public SubstanceValueType ValueType => SubstanceValueType.Image;
        public SubstanceInputDescription Description { get => _Description; set => _Description = value; }
        public ISubstanceInputDescNumerical NumericalDescription => null;

        public bool IsNumeric => false;

        [SerializeField]
        private Texture2D _Data;

        public Texture2D Data
        {
            get => _Data;
            set => _Data = value;
        }

        public bool IsVisible
        {
            get => _isVisible;
            set => _isVisible = true;
        }

        [SerializeField]
        private bool _HasChanged;

        public bool HasChanged
        {
            get => _HasChanged;
            set => _HasChanged = value;
        }

        public int GraphID => _GraphID;

        internal SubstanceInputTexture(int index, int graphID, DataInternalNumeric data)
        {
            _Index = index;
            _GraphID = graphID;
            _Data = null;
        }

        public void UpdateNativeHandle(SubstanceNativeHandler handler)
        {
            handler.SetInputTexture2D(_Data, _Index, _GraphID);
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