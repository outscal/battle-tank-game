using BattleTank.Enum;
using BattleTank.Services;
using BattleTank.Tank;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.PlayerTank
{
    public class PlayerTankController
    {
        private TankModel tankModel;
        private PlayerTankView playerTankView;
        private Rigidbody rigidBody;
        private bool isPlayerTankAlive;
        
        public PlayerTankController(TankModel _tankModel, PlayerTankView _playerTankView, Transform spawnPosition)
        {
            tankModel = _tankModel;
            playerTankView = GameObject.Instantiate<PlayerTankView>(_playerTankView, spawnPosition);

            UIService.Instance.PlayerHealthUI.SetUIColor(tankModel.BackgroundColor, tankModel.ForegroundColor);
            rigidBody = playerTankView.GetRigiBody();

            playerTankView.SetTankController(this);
            isPlayerTankAlive = true;
        }
        
        public Transform GetPlayerTransform()
        {
            return playerTankView.transform;
        }

        public void Move(float movement)
        {
            rigidBody.velocity = playerTankView.transform.forward * movement * tankModel.MovementSpeed;
        }

        public void Rotate(float rotation)
        {
            Vector3 vector = new Vector3(0f, rotation * tankModel.RotationSpeed, 0f);
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
            rigidBody.MoveRotation(rigidBody.rotation * deltaRotation);
        }

        public void UpdateTankColor(List<MeshRenderer> tankRenderer)
        {
            for(int i = 0; i < tankRenderer.Count; i++)
            {
                tankRenderer[i].material = tankModel.Material;
            }
        }

        public float GetFireRate()
        {
            return tankModel.FireRate;
        }

        public void SpawnBullet(Transform bulletTransform, Quaternion bulletRotation)
        {
            BulletService.Instance.SpawnBullet(tankModel.BulletType, bulletTransform, bulletRotation, TankID.Player);
        }

        public void TakeDamage(float damage)
        {
            if (tankModel.GetCurrentHealth() > 0)
            {
                tankModel.SetCurrentHealth(GetCurrentHealth() - damage);
            }
            
            if(((tankModel.GetCurrentHealth() / tankModel.Health) * tankModel.TotalPercentage) <= tankModel.HalfPercentage)
            {
                CollectibleService.Instance.LowHealth();
                playerTankView.SetArrowObjectActive(true);
            }

            if(tankModel.GetCurrentHealth() <= 0)
            {
                playerTankView.DestroyGameObject();
                isPlayerTankAlive = false;
            }
            
            UIService.Instance.PlayerHealthUI.SetHealthBarUI((tankModel.GetCurrentHealth() / tankModel.Health) * tankModel.TotalPercentage);
        }

        public void AddAdditionalHealth(float additionalHealthPercentage)
        {
            float additionalHealth = (additionalHealthPercentage / tankModel.TotalPercentage) * tankModel.Health;
            tankModel.SetCurrentHealth(tankModel.GetCurrentHealth() + additionalHealth);
            
            if (tankModel.GetCurrentHealth() > tankModel.Health)
            {
                tankModel.SetCurrentHealth(tankModel.Health);
            }

            if (((tankModel.GetCurrentHealth() / tankModel.Health) * tankModel.TotalPercentage) <= tankModel.HalfPercentage)
            {
                CollectibleService.Instance.LowHealth();
                playerTankView.SetArrowObjectActive(true);
            }

            UIService.Instance.PlayerHealthUI.SetHealthBarUI((tankModel.GetCurrentHealth() / tankModel.Health) * tankModel.TotalPercentage);
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }

        public bool GetIsPlayerTankALive()
        {
            return isPlayerTankAlive;
        }

        public void SetArrowObjectActive(bool _value)
        {
            playerTankView.SetArrowObjectActive(_value);
        }
    }
}