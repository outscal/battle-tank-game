using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public BulletType BulletType;
        public float health;
        public float movementSpeed;
        public float rotationSpeed;
        public float fireRate;
        public Material material;
    }
}