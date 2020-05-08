//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Enemy.Service;
using Enemy.View;
using Enemy.Model;
//using System;
using Bullet.Controller;


namespace Enemy.Controller
{
    public class EnemyController
    {
        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; }

        BulletController bulletController;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView, Vector3 position)
        {
            EnemyModel = enemyModel;
            EnemyView = GameObject.Instantiate<EnemyView>(enemyView, position, new Quaternion(0f, 0f, 0f, 0f));
            EnemyView.SetEnemyController(this);
        }

        public void MoveEnemy()
        {
            //to be implemented
        }

        public void FireBullet(Vector3 position, Vector3 tankRotation)
        {
            bulletController = EnemyService.Instance.GetBullet(position, tankRotation);
            bulletController.FireBullet(tankRotation);
        }

        public void DestroyEnemyTank()
        {
            EnemyView.InstantiateTankExplosionParticleEffect();
            EnemyView.DestroyEnemyTankPrefab();
            EnemyModel.ClearUpAllYourData();
            EnemyService.Instance.DestroyControllerAndModel();

        }
    }
}