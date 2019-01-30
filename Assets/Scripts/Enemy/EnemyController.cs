using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
    {
        public EnemyView enemyView { get; private set; }
        public EnemyModel enemyModel { get; private set; }

        public EnemyController(EnemyType enemyType, Vector3 position)
        {
            string enemyDataLocation = "";

            switch (enemyType)
            {
                case EnemyType.Blue:
                    enemyDataLocation = "BlueEnemy";
                    break;
                case EnemyType.Red:
                    enemyDataLocation = "RedEnemy";
                    break;
                case EnemyType.Yellow:
                    enemyDataLocation = "YellowEnemy";
                    break;
                default:
                    break;
            }

            ScriptableObjEnemy scriptableObjEnemy = Resources.Load<ScriptableObjEnemy>(enemyDataLocation);
            enemyModel = new EnemyModel();
            enemyModel.scriptableObj = scriptableObjEnemy;
            GameObject enemy = GameObject.Instantiate<GameObject>(enemyModel.scriptableObj.enemyPrefab);
            enemyView = enemy.GetComponent<EnemyView>();
            enemy.transform.position = position;
        }

    }
}