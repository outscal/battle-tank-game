using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/TankLists")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tankList;
    }
}
