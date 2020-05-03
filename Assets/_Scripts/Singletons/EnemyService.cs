using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;
using Enemy.View;
using Enemy.Model;
using Bullet.Service;
using System;
using Bullet.Controller;

namespace Enemy.Service
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyView EnemyView;
        EnemyModel enemyModel;
        EnemyController enemyController;

        List<EnemyController> enemyControllers = new List<EnemyController>();

        private void Update()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CreateNewEnemy();
                enemyControllers.Add(enemyController);
            }
        }

        private EnemyController CreateNewEnemy()
        {
            enemyModel = new EnemyModel();
            enemyController = new EnemyController(enemyModel, EnemyView);
            return enemyController;
        }

        public BulletController GetBullet(Vector3 position, Vector3 tankRotation)
        {
            BulletController bulletController = BulletService.Instance.PleaseGiveMeBullet(position, tankRotation);
            return bulletController;
        }

        public void DestroyControllerAndModel()
        {
            enemyModel = null;
            enemyControllers.Remove(enemyController);
            enemyController = null;
        }

        public IEnumerator DestroyAllEnemies()
        {
            Debug.Log("Destroy all enemies");
            for (int i = 0; i < enemyControllers.Count; i++)
            {
                if (enemyControllers[i] != null)
                {
                    yield return new WaitForSeconds(1f);
                    enemyControllers[i].DestroyEnemyTank();
                }
                else
                {
                    Debug.Log("enemy tank already destroyed");
                }
            }
        }
    }
}