using BattleTank.Enum;
using UnityEngine;

namespace BattleTank.TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public BulletType BulletType;
        public float Health;
        public float MovementSpeed;
        public float RotationSpeed;
        public float FireRate;
        public Material Material;
        public int TotalPercentage;
        public int HalfPercentage;
        public float DestroyTime;
    }
}