using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Controller;
using Tank.View;
using Tank.Model;
using Tank.ScriptableObjects;
using Bullet.Service;
using Bullet.Controller;
using ParticleSystem.Service;
using ParticleSystem.Controller;
using Enemy.Service;

namespace Tank.Service
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankView[] tankView;
        TankModel tankModel;
        TankController tankController;
        Dictionary<PlayerTankType, TankView> tankPrefab = new Dictionary<PlayerTankType, TankView>();

        public TankScriptableObject[] tankConfigurations;

        PlayerTankType tankType;

        private void Start()
        {
            for(int i = 0; i < tankView.Length; i++)
            {
                tankPrefab.Add((PlayerTankType)i, tankView[i]);
            }
        }

        private void Update()
        {
            SelectTankType();
        }

        private void SelectTankType()
        {
            //logic to set tankType vairiable.
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                tankType = PlayerTankType.Red;
                CreateNewTank();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                tankType = PlayerTankType.Green;
                CreateNewTank();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                tankType = PlayerTankType.Blue;
                CreateNewTank();
            }
            else if(Input.GetKeyDown(KeyCode.Alpha0))
            {
                tankType = PlayerTankType.None;
                CreateNewTank();
            }
        }

        private TankController CreateNewTank()
        {
            TankScriptableObject tankScriptableObject = tankConfigurations[(int)tankType]; // which tank needs to be created 
            tankModel = new TankModel(tankScriptableObject);

            tankController = new TankController(tankModel, tankPrefab);
            return tankController;
        }

        public void DestroyAllEnemies()
        {
            EnemyService.Instance.DestroyAll();
        }

        public ParticleEffectController GetParticleEffect(Vector3 position)
        {
            ParticleEffectController particleEffectController = ParticleEffectService.Instance.GetParticleEffect(position);
            return particleEffectController;
        }

        public void DestroyControllerAndModel()
        {
            //Debug.Log("tank controller and model destroyed");
            tankModel = null;
            tankController = null;
        }

        public void DestroyParticleEffect()
        {
            ParticleEffectService.Instance.DestroyParticleEffect();
        }

        public BulletController GetBullet(Vector3 position, Vector3 tankRotation)
        {
            BulletController bulletController = BulletService.Instance.PleaseGiveMeBullet(position, tankRotation);
            return bulletController;
        }
    }
}
