using BulletServices;
using UnityEngine;

namespace BulletSO
{ 
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/BulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        [Header("Bullet Prefab")]
        public BulletView bulletView;

        [Header("Bullet Type")]
        public BulletType bulletType;

        [Header("Shooting Parameters")]
        public int damage;
        public float explosionRadius;
        public float explosionForce;

        [Header("Time Parameters")]
        public float maxLifeTime;
    }
}


