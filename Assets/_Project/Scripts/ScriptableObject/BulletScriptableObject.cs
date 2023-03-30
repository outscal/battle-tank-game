using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletType BulletType;
        public float damage;
        public float speed;
    }
}