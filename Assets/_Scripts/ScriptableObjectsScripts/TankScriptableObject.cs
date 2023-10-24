using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public string TankName;
        public float Speed;
        public float Health;
        public BulletType BulletType;
        public TankView TankView;
    }

}