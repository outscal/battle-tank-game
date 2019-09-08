using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Bullet;

namespace TankBattle.Tank
{
    public class TankController
    {
        private ScreenOverlayManager gameUIService;
        private TankModel tankModel;
        private TankView tankView;
        private readonly BulletService bulletService;
        public TankController(TankScriptableObject _tankScriptableObject, Vector3 position)
        {
            tankModel = new TankModel(_tankScriptableObject);
            tankView = GameObject.Instantiate<TankView>(tankModel.TankPrefab, position, Quaternion.identity);
            tankView.SetController(this);
            bulletService = GameObject.FindObjectOfType<BulletService>();
            gameUIService = GameObject.FindObjectOfType<ScreenOverlayManager>();
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

        public int GetTankKills()
        {
            return tankModel.Kills;
        }

        public void ApplyDamage(int damage, TankController sourceTank)
        {
            tankModel.Health -= damage;
            gameUIService.UpdateUIHealthBar();
            if(tankModel.Health <= 0)
            {
                sourceTank.AddKill();
                DestroyTank();
            }
        }

        public void DestroyTank()
        {
            tankModel = null;
            GameObject.Destroy(tankView.gameObject);
            tankView = null;
        }

        public void AddKill()
        {
            tankModel.Kills++;
            gameUIService.UpdateUIScore();
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
