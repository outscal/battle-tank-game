using UnityEngine;
using Bullet;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "BulletConfiguration", menuName = "ScriptableObjects/NewBullet")]
    public class BulletScriptableObj : ScriptableObject
    {
        public BulletView BulletView;
        [Range(1, 20)]
        public int Speed;
        [Range(1, 20)]
        public float MaxDamage;
        [Range(1, 200)]
        public float ExplosionForce;
        [Range(1, 5)]
        public float MaxLifeTime;
        [Range(1, 10)]
        public float ExplosionRadius;
    }
}
