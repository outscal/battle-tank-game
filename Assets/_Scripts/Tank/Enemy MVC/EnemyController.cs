using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Service;
using Enemy.View;
using Enemy.Model;

namespace Enemy.Controller
{
    public class EnemyController
    {
        public EnemyModel EnemyModel { get; }
        public EnemyView EnemyView { get; }

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
        {
            Debug.Log("enemy controller created");
            EnemyModel = enemyModel;
            EnemyView = GameObject.Instantiate<EnemyView>(enemyView);
            EnemyView.SetEnemyController(this);
        }

        public void MoveEnemy()
        {
            //to be implemented
        }

        public void FireBullet()
        {
            EnemyService.Instance.FireBullet();
        }
    }
}