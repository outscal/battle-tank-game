using UnityEngine;
using EnemyScriptableObjects;

namespace EnemyTankServices
{
    public class EnemyTankModel
    {
        //Enemy Tank Info
        public float speed { get; }
        public int health { get; set; }
        public float rotationSpeed { get; }

        public Color tankColor { get; set; }
        public EnemyType enemyType { get; } // Type of enemy tank.

        // Patrolling
        public Vector3 patrolPoint { get; set; }
        public float patrolPointRange { get; set; }
        public bool b_IsPatrolPoint { get; set; }


        // States
        public float patrollingRange { get; set; }
        public float patrolTime { get; }
        public bool b_PlayerInSightRange { get; set; }
        public bool b_PlayerInAttackRange { get; set; }

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            speed = enemyTankScriptableObject.speed;
            health = enemyTankScriptableObject.health;
            rotationSpeed = enemyTankScriptableObject.rotationSpeed;

            tankColor = enemyTankScriptableObject.color;
            enemyType = enemyTankScriptableObject.enemyType;
                        
            patrolPointRange = enemyTankScriptableObject.patrolPointRange;
            b_IsPatrolPoint = false;

            patrolTime = enemyTankScriptableObject.patrolTime;
            patrollingRange = enemyTankScriptableObject.patrollingRange;
        }
    }
}
