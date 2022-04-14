using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Adobe.Substance.Input.Description;

namespace Adobe.Substance.Input
{
    /// <summary>
    /// Interface for representing all the different types of substance graph inputs.
    /// </summary>
    public interface ISubstanceInput
    {
        /// <summary>
        /// Input index inside the Substance Graph.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// Id of the owner substance Graph.
        /// </summary>
        int GraphID { get; }

        /// <summary>
        /// Input type.
        /// </summary>
        SubstanceValueType ValueType { get; }

        /// <summary>
        /// True if this input is numeric.
        /// </summary>
        bool IsNumeric { get; }

        /// <summary>
        /// True if this input is supported by the Unity plugin.
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        /// True if this input is visible in the editor (Editor only)
        /// </summary>
        bool IsVisible { get; set; }

        /// <summary>
        /// True if this input was changed in the editor UI (Editor only)
        /// </summary>
        bool HasChanged { get; set; }

        /// <summary>
        /// Description with aditional information about the input.
        /// </summary>
        SubstanceInputDescription Description { get; set; }

        /// <summary>
        /// Updates the native side of the substance engine with the current value for this input.
        /// </summary>
        /// <param name="handler"></param>
        void UpdateNativeHandle(SubstanceNativeHandler handler);

        /// <summary>
        /// Aditional information about this input (Only valid if input is numeric, null otherwise)
        /// </summary>
        ISubstanceInputDescNumerical NumericalDescription { get; }

        /// <summary>
        /// Assigns the native data from the substance engine to the numerical input description (Only valid if input is numeric)
        /// </summary>
        /// <param name="desc"></param>
        internal void SetNumericDescription(NativeNumericInputDesc desc);

        /// <summary>
        /// Assigns the native enum data from the substance engine to the numerical input description (Only valid if input is numeric)
        /// </summary>
        /// <param name="options"></param>
        internal void SetEnumOptions(NativeEnumInputDesc[] options);
    }
}