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

        private void Update()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CreateNewEnemy();
            }
        }

        private EnemyController CreateNewEnemy()
        {
            enemyModel = new EnemyModel();
            enemyController = new EnemyController(enemyModel, EnemyView);
            return enemyController;
        }

        public BulletController GetBullet(Vector3 position)
        {
            BulletController bulletController = BulletService.Instance.PleaseGiveMeBullet(position);
            return bulletController;
        }

        public void DestroyBullet()
        {
            BulletService.Instance.DestroyBullet();
        }

        public void DestroyControllerAndModel()
        {
            Debug.Log("enemy controller and model destroyed");
            enemyController = null;
            enemyModel = null;
        }
    }
}