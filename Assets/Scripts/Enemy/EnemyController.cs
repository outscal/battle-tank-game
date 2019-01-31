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
            GameObject enemy = GameObject.Instantiate<GameObject>(enemyModel.scriptableObj.enemyPrefab);
            enemyView = enemy.GetComponent<EnemyView>();
            enemyView.SetEnemyController(this);
            enemyView.setHealth(enemyModel.scriptableObj.health);
            enemy.transform.position = position;
        }

        public void DestroyEnemyModel()
        {
            enemyModel = null;
        }
    }
}