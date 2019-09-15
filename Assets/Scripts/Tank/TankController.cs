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
        private TankBotState currentState;
        private bool isBotTank = false;
        public TankController(TankScriptableObject _tankScriptableObject, Vector3 position)
        {
            tankModel = new TankModel(_tankScriptableObject);
            tankView = GameObject.Instantiate<TankView>(tankModel.TankPrefab, position, Quaternion.identity);
            tankView.SetController(this);
        }

        public void FireBullet()
        {
            Vector3 offsetHeight = new Vector3(0,1.8f,0);
            BulletService.Instance.TriggerBullet(tankView.transform.position + offsetHeight, tankView.transform.rotation, this);
        }

        public int GetTankHealth()
        {
            return tankModel.Health;
        }

        public int GetTankKills()
        {
            return tankModel.Kills;
        }

        public bool ApplyDamage(int damage, TankController sourceTank)
        {
            if(sourceTank == this)
                return false;//initially the bullets spawns inside tank and triggers collission

            tankModel.Health -= damage;
            if(tankModel.Health <= 0)
            {
                tankModel.Health = 0; //avoiding negative health
                sourceTank.AddKill();
                DestroyTank();
            }
            ScreenOverlayManager.Instance.UpdateUIHealthBar();

            return true;
        }

        public void DestroyTank()
        {
            tankModel = null;
            tankView.DestroyTankView();
            tankView = null;
        }

        public void AddKill()
        {
            tankModel.Kills++;
            ScreenOverlayManager.Instance.UpdateUIScore();
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

        public void EnableBotBehaviour(TankBotState initialState)
        {
            isBotTank = true;
            SetTankBotState(initialState);
        }

        public void SetTankBotState(TankBotState newState)
        {
            if (!isBotTank)
                return;

            if (currentState != null)
            {
                currentState.OnExitState();
            }
            currentState = newState;
            currentState.OnEnterState(this);
        }

        public void AimTo(Vector3 target)
        {
            tankView.AimTo(target);
        }
    }
}
