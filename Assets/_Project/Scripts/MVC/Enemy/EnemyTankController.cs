using BattleTank.Enum;
using BattleTank.Services;
using BattleTank.Services.ObjectPoolService;
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
        
        public EnemyTankController(TankModel _tankModel, EnemyTankView _enemyTankView, Vector3 spawnPosition, Transform _playerTransform, List<ColorType> colors)
        {
            tankModel = _tankModel;
            enemyTankView = _enemyTankView;
            playerTransform = _playerTransform;
            isTankAlive = true;

            SpawnTank(spawnPosition, colors);
        }

        private void SpawnTank(Vector3 spawnPosition, List<ColorType> colors)
        {
            enemyTankView = EnemyTankPoolService.Instance.GetItem();
            enemyTankView.SetEnemyTankController(this);
            enemyTankView.transform.position = spawnPosition;
            enemyTankView.gameObject.SetActive(true);
            enemyStateMachine = enemyTankView.GetEnemyStateMachine();
            enemyStateMachine.SetComponentsInEnemyStateMachine(this, enemyTankView, enemyTankView.GetNavMeshAgent(), tankModel.BulletType);

            UpdateHealthUIColor(colors);
        }

        private void UpdateHealthUIColor(List<ColorType> colors)
        {
            for (int i = 0; i < colors.Capacity; i++)
            {
                if (tankModel.TankType == colors[i].tankType)
                {
                    enemyTankView.GetEnemyHealthUI().SetUIColor(colors[i].backgroundColor, colors[i].foregroundColor);
                }
            }
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
            EnemyTankService.Instance.DecreaseEnemyCount();
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

            enemyTankView.GetEnemyHealthUI().SetHealthBarUI((tankModel.GetCurrentHealth() / tankModel.Health) * 100);
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }
        
        public float GetTankDestroyTime()
        {
            return tankModel.TankDestroyTime;
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
    }
}