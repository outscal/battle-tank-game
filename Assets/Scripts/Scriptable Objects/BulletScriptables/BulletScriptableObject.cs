using BulletServices;
using UnityEngine;

namespace BulletScriptables
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/BulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletView bulletView;
        public BulletType bulletType;
        public int damage;
        public float explosionRadius;
        public float explosionForce;
        public float maxLifeTime;
    }
}


