using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.View;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}