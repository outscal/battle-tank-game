using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;

        private Vector3 movementDirection;


        private float tankSpeed;
        private Rigidbody rb;
        private int health;

        public TankController(TankModel _tankModel, TankView _tankView)
        {
            tankModel = _tankModel;
            tankView = GameObject.Instantiate<TankView>(_tankView);



            tankSpeed = tankModel.Speed;
            rb = tankView.GetRigidbody();


            tankView.SetTankController(this);
            tankModel.SetTankController(this);
        }

        public Transform GetBulletSpwanTransfrom() => tankView.GetBulletSpawnPoint();
        private void ChangeTankColour()
        {
            for (int i = 0; i < tankView.GetTankBody().childCount; i++)
            {
                tankView.GetTankBody().GetChild(i).GetComponent<MeshRenderer>().material = tankModel.tankMaterial;
            }
        }

        public void Shoot(Transform gunTrasform)
        {
            TankService.Instance.ShootBullet(gunTrasform);
        }

        public void TankMove()
        {
            // Get the UIService instance
            UIService uiService = UIService.Instance;
            if (uiService == null)
            {
                Debug.LogError("UIService instance is missing or not properly initialized.");
                return;
            }

            movementDirection.x = uiService.GetJoystickHorizontal();

            movementDirection.z = uiService.GetJoystickVertical();


            tankView.GetRigidbody().velocity = movementDirection * tankModel.Speed * Time.fixedDeltaTime;
            if (movementDirection != Vector3.zero)
            {
                tankView.transform.forward = movementDirection;
            }
        }

        internal void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                TankDeath();
            }
        }

        private void TankDeath()
        {
            TankService.Instance.DestoryTank(tankView);
        }

        private TankModel GetModel()
        {
            return tankModel;
        }
    }
}