using System.Collections;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public string TankName;
        public float Speed;
        public float Health;
    }
}