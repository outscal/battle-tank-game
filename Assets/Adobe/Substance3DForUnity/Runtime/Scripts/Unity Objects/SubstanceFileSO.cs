using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adobe.Substance
{
    public class SubstanceFileSO : ScriptableObject
    {
        [SerializeField]
        public string AssetPath = default;

        [SerializeField]
        public List<SubstanceMaterialInstanceSO> Instances;
    }
}