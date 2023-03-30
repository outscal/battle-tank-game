using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class EnemyTankController
    {
        private TankModel tankModel;
        private EnemyTankView enemyTankView;
        private Transform playerTransform;
        
        public EnemyTankController(TankModel _tankModel, EnemyTankView _enemyTankView, Transform position, Transform _playerTransform)
        {
            tankModel = _tankModel;
            enemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView, position);
            playerTransform = _playerTransform;

            enemyTankView.SetEnemyTankController(this);
        }

        public Transform GetPlayerTank()
        {
            return playerTransform;
        }

        public void UpdateTankColor(List<MeshRenderer> tankBody)
        {
            for (int i = 0; i < tankBody.Count; i++)
            {
                tankBody[i].material = tankModel.material;
            }
        }

        public void TakeDamage(float damage)
        {
            if(tankModel.GetCurrentHealth() > 0)
            {
                float remainingHealth = GetCurrentHealth() - damage;
                tankModel.SetCurrentHealth(remainingHealth);
            }
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }

        public int GetNextDestination(int currentDestination, int posLength)
        {
            currentDestination--;
            if(currentDestination < 0)
            {
                currentDestination = posLength--;
            }

            return currentDestination;
        }

        public void SpawnBullet(Transform bulletTransform, Quaternion quaternion)
        {
            BulletService.Instance.SpawnBullet(tankModel.BulletType, bulletTransform, quaternion);
        }

        public float GetFireRate()
        {
            return tankModel.fireRate;
        }
    }
}