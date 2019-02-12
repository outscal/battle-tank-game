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
            EnemyManager.Instance.AlertMode += GetAlerted;
            enemyModel = new EnemyModel();
            enemyModel.scriptableObj = scriptableObjEnemy;
            GameObject enemy = GameObject.Instantiate<GameObject>(enemyModel.scriptableObj.enemyView.gameObject);
            enemyView = enemy.GetComponent<EnemyView>();
            enemyView.SetEnemyController(this);
            enemy.transform.position = position;
            enemyModel.CurrentHealth = enemyModel.scriptableObj.health;
            enemyView.TargetDetected += SendAlert;
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
            enemyView.TargetDetected -= SendAlert;
            EnemyManager.Instance.AlertMode -= GetAlerted;
            enemyView.DestroyEnemyView();
            enemyModel = null;
        }

        void GetAlerted(Vector3 position)
        {
            enemyView.FollowTarget(position);
        }

        void SendAlert(Vector3 position)
        {
            EnemyManager.Instance.AlertEnemies(position);
        }

        public int getScoreIncreaser()
        {
            return enemyModel.scriptableObj.scoreIncrease;
        }
    }
}