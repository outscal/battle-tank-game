using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;
using Enemy.View;
using Enemy.Model;
using Bullet.Service;
using System;

namespace Enemy.Service
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyView EnemyView;
        public BulletService BulletService;

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
            EnemyModel enemyModel = new EnemyModel();
            EnemyController enemyController = new EnemyController(enemyModel, EnemyView);
            return enemyController;
        }

        public void FireBullet()
        {
            Debug.Log("communicate with the bullet service to fire bullets at the player.");
        }
    }
}