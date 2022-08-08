using UnityEngine;

namespace BulletServices
{
    // Holds all the data related to bullet.
    public class BulletModel
    {
        public int bulletDamage { get; } // Damage applied by bullet.
        public float maxLifeTime { get; } // Maximum bullet life.
        public float explosionRadius { get; } 
        public float explosionForce { get; }
        public Vector3 currentVelocity { get; set; } // current velocity of bullet. 

        public BulletModel(int bulletDamage, float maxLifeTime, float explosionRadius, float explosionForce)
        {
            this.bulletDamage = bulletDamage;
            this.maxLifeTime = maxLifeTime;
            this.explosionRadius = explosionRadius;
            this.explosionForce = explosionForce;
        }
    }
}
