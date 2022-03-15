using BulletServices;
using EnemyScriptables;
using UnityEngine;

namespace EnemyTankServices
{
    public class EnemyTankModel
    {
        public int health { get; set; }
        public int maxHealth { get; }
        public float movementSpeed { get; }

        public float rotationSpeed { get; }
        public float turretRotationRate { get; }

        public float minLaunchForce { get; }
        public float maxLaunchForce { get; }

        public bool b_IsDead { get; set; }
        public bool b_IsFired { get; set; }

        public Color fullHealthColor { get; }
        public Color zeroHealthColor { get; }

        public EnemyType enemyType { get; }
        public BulletType bulletType { get; set; }

        // Patrolling
        public Vector3 walkPoint { get; set; }
        public float walkPointRange { get; set; }
        public bool b_IsWalkPoint { get; set; }

        // Attacking
        public float fireRate { get; set; }

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
