using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{
    [CreateAssetMenu(fileName = "ScriptableObjectList", menuName = "ScriptableObjectList/CreatListOfSO")]
    public class ScriptableObjectList : ScriptableObject
    {
        public TankScriptableObjects[] tank;
    }
}