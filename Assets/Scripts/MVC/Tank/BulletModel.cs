using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class BulletModel 
    {
        public int bulletDamage { get; }
        public float maxLifeTime { get; }
        public float explosionRadius { get; }
        public float explosionForce { get; }

        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            bulletDamage = bulletScriptableObject.damage;
            maxLifeTime = bulletScriptableObject.maxLifeTime;
            explosionRadius = bulletScriptableObject.explosionRadius;
            explosionForce = bulletScriptableObject.explosionForce;
        }

    }
}