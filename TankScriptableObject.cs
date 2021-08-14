using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType tankType;
        public string TankName;
        public float Speed;
        public float Health;
        public TankView TankView;
    }
}




