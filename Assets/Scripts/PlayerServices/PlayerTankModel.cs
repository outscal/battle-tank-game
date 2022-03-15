using BulletServices;
using TankScriptables;
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

        public Color tankColor { get; set; }


        public PlayerTankModel(TankScriptableObject playerData)
        {
            b_IsDead = false;
            b_IsFired = false;

            maxHealth = playerData.health;
            this.health = playerData.health;
            this.speed = playerData.movementSpeed;
            this.rotationRate = playerData.rotationSpeed;
            this.turretRotationRate = playerData.tankHeadRotation;
            this.minLaunchForce = playerData.minLaunchForce;
            this.maxLaunchForce = playerData.maxLaunchForce;
            currentLaunchForce = playerData.minLaunchForce;

            this.maxChargeTime = playerData.maxChargeTime;
            chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

            fullHealthColor = Color.green;
            zeroHealthColor = Color.red;

            tankColor = playerData.tankColor;

            this.bulletType = playerData.bulletType;
        }
    }
}
