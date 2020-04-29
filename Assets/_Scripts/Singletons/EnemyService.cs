using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;
using Enemy.View;
using Enemy.Model;
using Bullet.Service;
using System;
using Bullet.Controller;
using ParticleSystem.Controller;
using ParticleSystem.Service;

namespace Enemy.Service
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {
        public EnemyView EnemyView;
        //EnemyModel enemyModel;
        EnemyController enemyController;
        List<EnemyController> enemyControllers;

        private void Start()
        {
            enemyControllers = new List<EnemyController>();
        }

        private void Update()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //enemyControllers.Add(CreateNewEnemy());
                CreateNewEnemy();
                enemyControllers.Add(enemyController);
            }
        }

        private void CreateNewEnemy()
        {
            //enemyModel = new EnemyModel();
            enemyController = new EnemyController(EnemyView);
            //return enemyController;
        }

        public BulletController GetBullet(Vector3 position, Vector3 tankRotation)
        {
            BulletController bulletController = BulletService.Instance.PleaseGiveMeBullet(position, tankRotation);
            return bulletController;
        }

        public ParticleEffectController GetParticleEffect(Vector3 position)
        {
            ParticleEffectController particleEffectController = ParticleEffectService.Instance.GetParticleEffect(position);
            return particleEffectController;
        }

        public void DestroyControllerAndModel()
        {
            //Debug.Log("enemy controller and model destroyed");
            enemyController = null;
            //enemyModel = null;
        }

        public void DestroyAll()
        {
            Debug.Log("Destroy all enemies");
            for (int i = 0; i < enemyControllers.Count; i++)
            {
                enemyControllers[i].GetRequestOfParticleEffectFromView();
                enemyControllers[i].DestroyViewAndModel();
                enemyControllers[i] = null;
            }
        }
    }
}