using BulletServices;
using TankSO;
using UnityEngine;

namespace PlayerTankServices
{
    // Holds all the data related to player tank.
    public class PlayerTankModel
    {
        public int maxHealth { get; }
        public int health { get; set; }
        public float speed { get; } // Tank movement speed.
        public float rotationRate { get; } // Tank rotation speed.
        public float turretRotationRate { get; } // Turret rotation speed.

        public float minLaunchForce { get; } // Minimum bullet launch force.
        public float maxLaunchForce { get; } // Maximum bullet launch force.
        public float currentLaunchForce { get; set; } // The force that will be given to the bullet when the fired.
        public float maxChargeTime { get; } // How long the bullet can charge for before it is fired at max force.
        public float chargeSpeed { get; } // How fast the launch force increases, based on the max charge time.

        public int bulletsFired { get; set; } // Number of bullets fired by player tank.
        public int enemiesKilled { get; set; } // Number of enemies killed by player tank.
        public int waveSurvived { get; set; } // Number of waves survived by player tank.

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
            this.turretRotationRate = playerData.turretRotationRate;

            this.minLaunchForce = playerData.minLaunchForce;
            this.maxLaunchForce = playerData.maxLaunchForce;
            currentLaunchForce = playerData.minLaunchForce;

            this.maxChargeTime = playerData.maxChargeTime;
            chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;

            fullHealthColor = Color.green;
            zeroHealthColor = Color.red;

            tankColor = playerData.tankColor;

            this.bulletType = playerData.bulletType;

            waveSurvived = -1;
        }
    }
}
