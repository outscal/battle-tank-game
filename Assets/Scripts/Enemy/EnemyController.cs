using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyView enemyView { get; private set; }
        public EnemyModel enemyModel { get; private set; }

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
//            Debug.Log("[EnemyView] Value: " + value + " Health: " + enemyModel.CurrentHealth);
            if (enemyModel.CurrentHealth <= 0)
            {
                enemyView.DestroyEnemy();
            }
        }

        public void DestroyEnemyModel()
        {
            enemyModel = null;
        }
    }
}