using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Bullet;

namespace TankBattle.Tank
{
    public class TankController
    {
        public bool IsBotTank {get {return isBotTank; }}
        private bool isBotTank = false;
        private bool isLoaded;
        private TankBotState currentBotState;
        private TankModel tankModel;
        private TankView tankView;
        public TankController(TankScriptableObject _tankScriptableObject, Vector3 position)
        {
            tankModel = new TankModel(_tankScriptableObject);
            tankView = GameObject.Instantiate<TankView>(tankModel.TankPrefab, position, Quaternion.identity);
            tankView.SetController(this);
            isLoaded = true;
        }

        public void FireBullet()
        {
            if (isLoaded)
            {
                Vector3 offsetHeight = new Vector3(0,1.8f,0);
                BulletService.Instance.TriggerBullet(tankView.transform.position + offsetHeight, tankView.transform.rotation, this);
                isLoaded = false;
                Reload();
                
            }
        }

        private async void Reload()
        {
            // await Task.Delay(TimeSpan.FromSeconds(1));
            isLoaded = true;
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
            tankView.gameObject.transform.position = tankView.gameObject.transform.position + (tankView.gameObject.transform.forward * tankModel.Speed);
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

        public void MoveTo(Vector3 destination)
        {
            tankView.transform.position = destination;
        }
        public void LookTo(Vector3 direction)
        {
            tankView.LookTo(direction);
        }

        public void EnableBotBehaviour()
        {
            isBotTank = true;
            ChangeState(tankView.GetComponent<PatrollingState>());
        }

        public void ChangeState(TankBotState newState)
        {
            if (!IsBotTank)
                return;

            if (currentBotState != null)
            {
                currentBotState.OnExitState();
            }
            currentBotState = newState;
            currentBotState.OnEnterState(this, tankView);
        }

        public Vector3 GetTankPosition()
        {
            return tankView.transform.position;
        }

        public bool IsTargetTankInShootingRange(TankController targetTank)
        {
            if(Vector3.Distance(GetTankPosition(), targetTank.GetTankPosition()) < tankModel.ShootingRange)
                return true;
            else
                return false;
        }

        public bool IsTargetTankInDetectionRange(TankController targetTank)
        {
            if(Vector3.Distance(GetTankPosition(), targetTank.GetTankPosition()) < tankModel.EnemyDetectionRange)
                return true;
            else
                return false;
        }
    }
}
