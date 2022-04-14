using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance
{
    /// <summary>
    /// Scriptable object to store information about an instance of a sbsar file. Each instance has it own input values and output textures.
    /// </summary>
    public class SubstanceMaterialInstanceSO : ScriptableObject
    {
        /// <summary>
        /// Path to the sbsar file that owns this instance. (Editor only)
        /// </summary>
        [SerializeField]
        public string AssetPath = default;

        /// <summary>
        /// Folder where assets related to this instance should be placed. (Editor only)
        /// </summary>
        [SerializeField]
        public string OutputPath = default;

        [SerializeField]
        public SubstanceFileRawData RawData = default;

        /// <summary>
        /// List of graphs in this substance material.
        /// </summary>
        [SerializeField]
        public List<SubstanceGraph> Graphs;

        /// <summary>
        /// Flag that tells the substance engine that it should render the output of this object.
        /// </summary>
        [SerializeField]
        public bool RefreshMaterial = false;

        /// <summary>
        /// Name for the instance.
        /// </summary>
        [SerializeField]
        public string Name = default;

        /// <summary>
        /// Is root instance.
        /// </summary>
        [SerializeField]
        public bool IsRoot = false;

        /// <summary>
        /// Signalized for the API that this instance should be deleted. (Editor only)
        /// </summary>
        [SerializeField]
        public bool FlagedForDelete = false;

        /// <summary>
        /// GUI to uniquely identify this instance during runtime.
        /// </summary>
        [SerializeField]
        public string GUID = default; 
    }
}