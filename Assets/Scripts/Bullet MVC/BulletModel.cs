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
        public float maxLifeTime { get; } // Maximum bullet life.
        public Vector3 currentVelocity { get; set; } // current velocity of bullet. 

        public BulletModel(int bulletDamage, float maxLifeTime)
        {
            this.bulletDamage = bulletDamage;
            this.maxLifeTime = maxLifeTime;
        }
    }
}
