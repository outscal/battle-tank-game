using BulletServices;
using EnemySO;
using UnityEngine;

namespace EnemyTankServices
{
    // Holds all the data related to enemy tank.
    public class EnemyTankModel
    {
        public int health { get; set; }
        public int maxHealth { get; }
        public float movementSpeed { get; }

        public float rotationSpeed { get; }
        public float turretRotationRate { get; }

        public float minLaunchForce { get; } // Minimum bullet launch force.
        public float maxLaunchForce { get; } // Maximum bullet launch force.

        public bool b_IsDead { get; set; }
        public bool b_IsFired { get; set; } 

        public Color fullHealthColor { get; }
        public Color zeroHealthColor { get; }

        public EnemyType enemyType { get; } // Type of enemy tank.
        public BulletType bulletType { get; set; } // Type of bullet fired.

        // Patrolling
        public Vector3 walkPoint { get; set; } // Desired position of enemy tank.
        public float walkPointRange { get; set; }
        public bool b_IsWalkPoint { get; set; } // Is walk point selected.

        // Attacking
        public float fireRate { get; set; } // Bullet fire rate.

        // States
        public float patrollingRange { get; set; }
        public float patrolTime { get; }
        public float attackRange { get; set; }
        public bool b_PlayerInSightRange { get; set; }
        public bool b_PlayerInAttackRange { get; set; }

        public Color tankColor { get; set; }


        public EnemyTankModel(EnemyScriptableObject enemyData)
        {
            health = enemyData.health;
            maxHealth = enemyData.health;

            movementSpeed = enemyData.movementSpeed;
            rotationSpeed = enemyData.rotationSpeed;
            turretRotationRate = enemyData.turretRotationRate;

            b_IsWalkPoint = false;
            b_IsDead = false;
            walkPointRange = enemyData.walkPointRange;

            patrolTime = enemyData.patrolTime;
            patrollingRange = enemyData.patrollingRange;
            attackRange = enemyData.attackRange;

            enemyType = enemyData.enemyType;

            bulletType = enemyData.bulletType;
            fireRate = enemyData.fireRate;
            minLaunchForce = enemyData.minLaunchForce;
            maxLaunchForce = enemyData.maxLaunchForce;

            fullHealthColor = Color.green;
            zeroHealthColor = Color.red;

            tankColor = enemyData.tankColor;
        }
    }
}
