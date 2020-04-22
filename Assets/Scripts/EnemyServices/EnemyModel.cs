using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using EnemySO;
using BulletSO;

namespace EnemyServices
{
    public class EnemyModel
    {
        public EnemyType enemyType { get; private set; }
        public float movementSpeed { get; private set; }
        public float rotationSpeed { get; private set; }

        public float patrollingRadius { get; private set; }
        public float patrolTime { get; private set; }

        public float fireRate { get; private set; }
        public float attackDist { get; private set; }
        public BulletScriptableObject bullet { get; private set; }

        public float health { get; private set; }

        private EnemyController controller;


        public EnemyModel(EnemyScriptableObject enemyData)
        {
            enemyType = enemyData.enemyType;
            movementSpeed = enemyData.movementSpeed;
            rotationSpeed = enemyData.rotationSpeed;
            patrollingRadius = enemyData.patrollingRadius;
            patrolTime = enemyData.patrolTime;
            fireRate = enemyData.fireRate;
            attackDist = enemyData.attackDistace;
            bullet = enemyData.bulletType;
            health = enemyData.health;
        }


        public void SetEnemyController(EnemyController _controller)
        {
            controller = _controller;
        }
        public void DestroyModel()
        {
            bullet = null;
            controller = null;
        }
    }
}