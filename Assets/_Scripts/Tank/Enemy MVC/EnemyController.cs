using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Service;
using Enemy.View;
using Enemy.Model;
using System;
using Bullet.Controller;
using ParticleSystem.Controller;

namespace Enemy.Controller
{
    public class EnemyController
    {
        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; }

        BulletController bulletController;
        ParticleEffectController particleEffectController;

        public EnemyController(EnemyView enemyView)
        {
            //Debug.Log("enemy controller created");
            //EnemyModel = enemyModel;
            EnemyModel = new EnemyModel();
            EnemyView = GameObject.Instantiate<EnemyView>(enemyView);
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

        public void SetOffParticleEffect(Vector3 position)
        {
            particleEffectController = EnemyService.Instance.GetParticleEffect(position);
        }

        public void DestroyController()
        {
            EnemyModel = null;
            EnemyService.Instance.DestroyControllerAndModel();
        }

        public void DestroyViewAndModel()
        {
            EnemyModel = null;
            EnemyView.DestroyView();
        }

        public void GetRequestOfParticleEffectFromView()
        {
            EnemyView.ParticleEffect();
        }
    }
}