using BulletServices;
using UnityEngine;

namespace PlayerTankServices
{
    public class PlayerTankModel
    {
        public int maxHealth { get; }
        public int health { get; set; }
        public float speed { get; }
        public float rotationRate { get; }
        public float turretRotationRate { get; }

        public float minLaunchForce { get; }
        public float maxLaunchForce { get; }
        public float currentLaunchForce { get; set; }
        public float maxChargeTime { get; }
        public float chargeSpeed { get; }

        public bool b_IsDead { get; set; }

        public bool b_IsFired { get; set; }

        public Color fullHealthColor { get; }
        public Color zeroHealthColor { get; }

        public BulletType bulletType { get; }


        public PlayerTankModel(int health, float speed, float rotationRate, float turretRotationRate, BulletType bulletType, float maxLaunchForce, float minLaunchForce, float maxChargeTime)
        {
            b_IsDead = false;
            b_IsFired = false;

            maxHealth = health;
            this.health = health;
            this.speed = speed;
            this.rotationRate = rotationRate;
            this.turretRotationRate = turretRotationRate;

            this.minLaunchForce = minLaunchForce;
            this.maxLaunchForce = maxLaunchForce;
            currentLaunchForce = minLaunchForce;

            this.maxChargeTime = maxChargeTime;
            chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

            fullHealthColor = Color.green;
            zeroHealthColor = Color.red;

            this.bulletType = bulletType;
        }
    }
}
