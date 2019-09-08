using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Bullet;

namespace TankBattle.Tank
{
    public class TankController
    {
        private TankModel tankModel;
        private TankView tankView;
        private readonly BulletService bulletService;
        public TankController(TankScriptableObject _tankScriptableObject, Vector3 position)
        {
            tankModel = new TankModel(_tankScriptableObject);
            tankView = GameObject.Instantiate<TankView>(tankModel.TankPrefab, position, Quaternion.identity);
            tankView.SetController(this);
            bulletService = GameObject.FindObjectOfType<BulletService>();
        }

        public void FireBullet()
        {
            Vector3 offsetHeight = new Vector3(0,1.8f,0);
            bulletService.TriggerBullet(tankView.transform.position + offsetHeight, tankView.transform.rotation, this);
        }

        public int GetTankHealth()
        {
            return tankModel.Health;
        }

        public void ApplyDamage(int damage)
        {
            tankModel.Health -= damage;
            if(tankModel.Health <= 0)
            {
                DestroyTank();
            }
        }

        public void DestroyTank()
        {
            tankModel = null;
            GameObject.Destroy(tankView.gameObject);
            tankView = null;
        }

        public void MoveForward()
        {
            tankView.transform.position = tankView.transform.position + (tankView.transform.forward * tankModel.Speed);
        }
        public void MoveBackWard()
        {
            tankView.transform.position = tankView.transform.position + (tankView.transform.forward * -tankModel.Speed);
        }
        public void TurnLeft()
        {
            tankView.transform.Rotate(Vector3.up*tankModel.TurningTorque);
        }
        public void TurnRight()
        {
            tankView.transform.Rotate(Vector3.up*-tankModel.TurningTorque);
        }
    }
}
