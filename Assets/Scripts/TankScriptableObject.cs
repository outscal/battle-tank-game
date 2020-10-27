using UnityEngine;


namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewTankObject", menuName = "TankObject")]
    public class TankScriptableObject : ScriptableObject
    {
        public int health;
        public int bulletDamage;
        public float moveSpeed;
        public float bulletSpeed;
    }
}
