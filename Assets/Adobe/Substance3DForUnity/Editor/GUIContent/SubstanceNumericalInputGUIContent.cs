using Adobe.Substance.Input.Description;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    /// <summary>
    /// Custome GUIContent class that provides extra information for drawing numeric input parameters.
    /// </summary>
    internal class SubstanceNumericalInputGUIContent : SubstanceInputGUIContent
    {
        /// <summary>
        /// Numerical input description for the target SerializedProperty.
        /// </summary>
        public ISubstanceInputDescNumerical NumericalDescription;

        public SubstanceNumericalInputGUIContent(SubstanceInputDescription description, ISubstanceInputDescNumerical numDescription) : base(description)
        {
            NumericalDescription = numDescription;
        }

        public SubstanceNumericalInputGUIContent(SubstanceInputDescription description, ISubstanceInputDescNumerical numDescription, string text) : base(description, text)
        {
            NumericalDescription = numDescription;
        }
    }
}