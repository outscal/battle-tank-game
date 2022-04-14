using Adobe.Substance.Input.Description;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance.Editor
{
    /// <summary>
    /// Custome GUIContent class that provides extra information for drawing input parameters.
    /// </summary>
    internal class SubstanceInputGUIContent : GUIContent
    {
        /// <summary>
        /// Description info for the input SerializedProperty.
        /// </summary>
        public SubstanceInputDescription Description;

        public SubstanceInputGUIContent(SubstanceInputDescription description) : base(description.Label, description.Identifier)
        {
            Description = description;
        }

        public SubstanceInputGUIContent(SubstanceInputDescription description, string text) : base(text)
        {
            Description = description;
        }
    }
}