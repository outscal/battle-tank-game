using System;
using UnityEngine;

namespace Outscal.BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObject",menuName = "ScriptableObjects/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public string TankName;
        public float Speed;
        public float rotationSpeed;
        public int Health;
        public TankView TankView;

    }

    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}