using UnityEngine;
using EnemyScriptableObjects;
using BulletServices;

namespace EnemyTankServices
{
    public class EnemyTankModel
    {
        //Enemy Tank Info
        public float speed { get; }
        public int health { get; set; }
        public float rotationSpeed { get; }
        public float turretRotationSpeed { get; }

        public Color tankColor { get; set; }
        public EnemyType enemyType { get; } // Type of enemy tank.
        public BulletType bulletType { get; set; } // Type of bullet fired.

        // Patrolling
        public Vector3 patrolPoint { get; set; }
        public float walkPointRange { get; set; }
        public bool b_IsPatrolPoint { get; set; }

        public bool b_IsDead { get; set; }
        public bool b_IsFired { get; set; }

        // States
        public float patrollingRange { get; set; }
        public float patrolTime { get; }
        public float attackRange { get; set; }
        public bool b_PlayerInSightRange { get; set; }
        public bool b_PlayerInAttackRange { get; set; }

        public float minLaunchForce { get; } // Minimum bullet launch force.
        public float maxLaunchForce { get; } // Maximum bullet launch force.
        
        // Attacking
        public float fireRate { get; set; } // Bullet fire rate.

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            speed = enemyTankScriptableObject.speed;
            health = enemyTankScriptableObject.health;
            rotationSpeed = enemyTankScriptableObject.rotationSpeed;
            turretRotationSpeed = enemyTankScriptableObject.turretRotationSpeed;

            tankColor = enemyTankScriptableObject.color;
            enemyType = enemyTankScriptableObject.enemyType;

            walkPointRange = enemyTankScriptableObject.walkPointRange;
            b_IsPatrolPoint = false;

            patrolTime = enemyTankScriptableObject.patrolTime;
            patrollingRange = enemyTankScriptableObject.patrollingRange;
            attackRange = enemyTankScriptableObject.attackRange;

            bulletType = enemyTankScriptableObject.bulletType;
            fireRate = enemyTankScriptableObject.fireRate;
            minLaunchForce = enemyTankScriptableObject.minLaunchForce;
            maxLaunchForce = enemyTankScriptableObject.maxLaunchForce;
        }
    }
}
