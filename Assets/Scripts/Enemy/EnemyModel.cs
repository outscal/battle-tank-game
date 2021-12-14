using BulletServices;
using BulletSO;
using EnemySO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyServices
{
    public class EnemyModel 
    {
        public EnemyType enemyType { get; private set; }
        public float health { get; private set; }
        public float moveSpeed { get; private set; }
        public float rotateSpeed { get; private set; }
        public BulletScriptableObject bulletType { get; private set; }

        private EnemyController enemyController;

        public EnemyModel(EnemyScriptableObject enemyScriptableObject)
        {
            enemyType = enemyScriptableObject.enemyType;
            health = enemyScriptableObject.health;
            moveSpeed = enemyScriptableObject.moveSpeed;
            rotateSpeed = enemyScriptableObject.rotateSpeed;
            bulletType = enemyScriptableObject.bulletType;
        }

        public void setEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }

    }
}
