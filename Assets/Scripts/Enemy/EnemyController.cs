using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyView enemyView { get; private set; }
        public EnemyModel enemyModel { get; private set; }

        public event Action DestroyEnemy;

        public EnemyController(ScriptableObjEnemy scriptableObjEnemy, Vector3 position)
        {
            enemyModel = new EnemyModel();
            enemyModel.scriptableObj = scriptableObjEnemy;
            GameObject enemy = GameObject.Instantiate<GameObject>(enemyModel.scriptableObj.enemyView.gameObject);
            enemyView = enemy.GetComponent<EnemyView>();
            enemyView.SetEnemyController(this);
            enemy.transform.position = position;
            enemyModel.CurrentHealth = enemyModel.scriptableObj.health;

        }

        public void TakeDamage(int value)
        {
            enemyModel.CurrentHealth -= value;
            if (enemyModel.CurrentHealth <= 0)
            {
                DestroyEnemy?.Invoke();
            }
        }

        public void DestroyEnemyModel()
        {
            enemyModel = null;
        }

        public int getScoreIncreaser()
        {
            return enemyModel.scriptableObj.scoreIncrease;
        }
    }
}