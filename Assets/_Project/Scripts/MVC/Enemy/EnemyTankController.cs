using BattleTank.Services;
using BattleTank.Tank;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.EnemyTank
{
    public class EnemyTankController
    {
        private TankModel tankModel;
        private EnemyTankView enemyTankView;
        private Transform playerTransform;
        private bool isTankAlive;
        
        public EnemyTankController(TankModel _tankModel, EnemyTankView _enemyTankView, Transform spawnPosition, Transform _playerTransform)
        {
            tankModel = _tankModel;
            enemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView, spawnPosition);
            playerTransform = _playerTransform;
            isTankAlive = true;

            enemyTankView.SetEnemyTankController(this);
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

        public void TakeDamage(float damage)
        {
            if(tankModel.GetCurrentHealth() > 0)
            {
                tankModel.SetCurrentHealth(GetCurrentHealth() - damage);
            }

            if(tankModel.GetCurrentHealth() <= 0)
            {
                DestroyTank();
            }
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }
        
        public void SpawnBullet(Transform bulletTransform, Quaternion bulletRotation)
        {
            BulletService.Instance.SpawnBullet(tankModel.BulletType, bulletTransform, bulletRotation);
        }

        public float GetFireRate()
        {
            return tankModel.FireRate;
        }

        public void DestroyTank()
        {
            enemyTankView.DestroyGameObject();
        }

        public float GetTankDestryTime()
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
    }
}