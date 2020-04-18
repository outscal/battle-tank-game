using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Controller;
using Tank.View;
using Tank.Model;
using Tank.ScriptableObjects;
using Bullet.Service;

namespace Tank.Service
{
    public class TankService : MonoSingletonGeneric<TankService>
    {
        public TankView[] tankView;
        public BulletService BulletService;

        public TankScriptableObject[] tankConfigurations;

        PlayerTankType tankType;

        //private void Start()
        //{
              //SelectTankType();
        //}

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
            TankModel tankModel = new TankModel(tankScriptableObject);

            //TankModel tankModel = new TankModel(TankType.None, 15f);
            TankController tankController = new TankController(tankModel, tankView);
            tankController.SetTankService(this);
            return tankController;
        }

        public void FireBullet(Vector3 position, Vector3 tankRotation)
        {
            BulletService.CreateNewBullet(position, tankRotation);
        }
    }
}
