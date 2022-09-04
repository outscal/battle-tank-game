using UnityEngine;

/// <summary>
/// This Function stores & is used to reference the data about a Bullet entity.
/// </summary>

namespace BulletServices
{
    // Holds all the data related to bullet.
    public class BulletModel
    {
        public int bulletDamage { get; } // Damage applied by bullet.
        public float maxBulletLifeTime { get; } // Maximum bullet life.
        public float radiusOfExplosion { get; }
        public float forceOfExplosion { get; }
        public Vector3 currentVelocity { get; set; } // current velocity of bullet. 

        public BulletModel(int bulletDamage, float maxBulletLifeTime, float radiousOfExplosion, float forceOfExplosion)
        {
            this.bulletDamage = bulletDamage;
            this.maxBulletLifeTime = maxBulletLifeTime;
            this.radiusOfExplosion = radiousOfExplosion;
            this.forceOfExplosion = forceOfExplosion;
        }
    }
}
