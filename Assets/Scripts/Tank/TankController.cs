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
        private BulletService bulletService;

        private Rigidbody tankRigidBody;
        public TankController(TankView _tankPrefab, Vector3 position)
        {
            tankModel = new TankModel();
            tankView = GameObject.Instantiate<TankView>(_tankPrefab, position, Quaternion.identity);
            bulletService = GameObject.FindObjectOfType<BulletService>();
            tankRigidBody = tankView.GetComponent<Rigidbody>();
        }

        public void FireBullet()
        {
            Vector3 offsetHeight = new Vector3(0,1.8f,0);
            bulletService.TriggerBullet(tankView.transform.position + offsetHeight, tankView.transform.rotation);
        }

        public void ApplyDamage(int damage)
        {
            tankModel.health -= damage;
            if(tankModel.health <= 0)
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
            tankView.transform.position = tankView.transform.position + (tankView.transform.forward * tankModel.speed);
        }
        public void MoveBackWard()
        {
            tankView.transform.position = tankView.transform.position + (tankView.transform.forward * -tankModel.speed);
        }
        public void TurnLeft()
        {
            tankView.transform.Rotate(Vector3.up*2);
        }
        public void TurnRight()
        {
            tankView.transform.Rotate(Vector3.up*-2);
        }
    }
}
