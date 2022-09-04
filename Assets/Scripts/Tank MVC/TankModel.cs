using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankScriptableObjects;
using BulletServices;

namespace TankServices {
    public class TankModel
    {
        private TankController tankController;

        // TankModel -> controller
        public void SetTankControllerReference(TankController _tankController)
        {
            tankController = _tankController;
        }

        public TankModel(TankScriptableObject tankScriptableObject)
        {
            b_IsDead = false;
            bulletIsFired = false;

            maxHealth = tankScriptableObject.tankHealth;
            this.health = tankScriptableObject.tankHealth;
            this.rotationSpeed = tankScriptableObject.rotationSpeed;
            movementSpeed = tankScriptableObject.tankSpeed;
            this.turretRotationSpeed = tankScriptableObject.turretRotationSpeed;

            this.minBulletLaunchForce = tankScriptableObject.minLaunchForce;
            this.maxBulletLaunchForce = tankScriptableObject.maxLaunchForce;
            currentLaunchForce = tankScriptableObject.minLaunchForce;

            this.maxChargeTime = tankScriptableObject.maxChargeTime;
            chargeSpeed = (maxBulletLaunchForce - minBulletLaunchForce) / maxChargeTime;

            this.tankType = tankScriptableObject.tankType;
            this.bulletType = tankScriptableObject.bulletType;            
            
            TankColor = tankScriptableObject.tankColor;
        }

        public TankType tankType { get; }
        public BulletType bulletType;

        public float movementSpeed { get; }
        
        public int maxHealth { get; } // Tank Maximum Health
        public int health { get; set; } 
        public float rotationSpeed { get; } // Tank rotation speed.
        public float turretRotationSpeed { get; } 

        public float minBulletLaunchForce { get; } 
        public float maxBulletLaunchForce { get; } 
        public float currentLaunchForce { get; set; } // The force that will be given to the bullet when the fired.
        public float maxChargeTime { get; } // How long the bullet can charge for before it is fired at max force.
        public float chargeSpeed { get; } // How fast the launch force increases, based on the max charge time.

        public int bulletsFired { get; set; } // Number of bullets fired by player tank.
        public int enemiesKilled { get; set; } // Number of enemies killed by player tank.

        public bool b_IsDead { get; set; }
        public bool bulletIsFired { get; set; }

        public Color TankColor { get; set; }
    }
}
