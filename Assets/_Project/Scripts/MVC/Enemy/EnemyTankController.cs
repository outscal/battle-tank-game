using BattleTank.Enum;
using BattleTank.Services;
using BattleTank.StateMachine.EnemyState;
using BattleTank.Tank;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyTankController
    {
        private TankModel tankModel;
        private EnemyTankView enemyTankView;
        private EnemyStateMachine enemyStateMachine;
        private Transform playerTransform;
        private bool isTankAlive;
        
        public EnemyTankController(TankModel _tankModel, EnemyTankView _enemyTankView, Vector3 spawnPosition, Transform _playerTransform)
        {
            tankModel = _tankModel;
            enemyTankView = _enemyTankView;
            playerTransform = _playerTransform;
            isTankAlive = true;

            SpawnTank(spawnPosition);
        }

        private void SpawnTank(Vector3 spawnPosition)
        {
            enemyTankView = EnemyTankService.Instance.GetEnemyTankPoolService().GetItem(ObjectPoolType.EnemyTankPool);
            enemyTankView.SetEnemyTankController(this);
            enemyTankView.transform.position = spawnPosition;
            enemyTankView.gameObject.SetActive(true);
            enemyStateMachine = enemyTankView.GetEnemyStateMachine();
            enemyStateMachine.SetComponentsInEnemyStateMachine(this, enemyTankView, enemyTankView.GetNavMeshAgent(), tankModel.BulletType);

            UpdateHealthUIColor();
        }

        private void UpdateHealthUIColor()
        {
            enemyTankView.GetEnemyHealthUI().SetUIColor(tankModel.Material.color);
            enemyTankView.GetEnemyHealthUI().SetPlayerTransform(PlayerTankService.Instance.GetPlayerTank());
        }

        public Transform GetPlayerTank()
        {
            return playerTransform;
        }

        public void UpdateTankColor(List<MeshRenderer> tankRenderer)
        {
            for (int i = 0; i < tankRenderer.Count; i++)
            {
                tankRenderer[i].material = tankModel.Material;
            }
        }

        public void DestroyTank()
        {
            enemyStateMachine.SetState(enemyStateMachine.DeadState);
        }

        public void TakeDamage(TankID shooter, float damage)
        {
            if(tankModel.GetCurrentHealth() > 0)
            {
                tankModel.SetCurrentHealth(GetCurrentHealth() - damage);
            }

            if(tankModel.GetCurrentHealth() <= 0)
            {
                DestroyTank();
                EventService.Instance.OnTankDestroyed(shooter, TankID.Enemy);
            }

            enemyTankView.GetEnemyHealthUI().SetHealthBarUI((tankModel.GetCurrentHealth() / tankModel.Health) * tankModel.TotalPercentage);
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }

        public void SetIsTankAlive(bool _boolvalue)
        {
            isTankAlive = _boolvalue;
        }

        public bool GetIsTankAlive()
        {
            return isTankAlive;
        }

        public EnemyTankView GetEnemyTankView()
        {
            return enemyTankView;
        }

        public float GetDestroyTime()
        {
            return tankModel.DestroyTime;
        }
    }
}