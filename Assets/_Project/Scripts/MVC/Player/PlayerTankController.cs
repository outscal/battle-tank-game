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
        
        public PlayerTankController(TankModel _tankModel, PlayerTankView _playerTankView, Transform spawnPosition)
        {
            tankModel = _tankModel;
            playerTankView = GameObject.Instantiate<PlayerTankView>(_playerTankView, spawnPosition);
            
            rigidBody = playerTankView.GetRigiBody();

            playerTankView.SetTankController(this);
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
            BulletService.Instance.SpawnBullet(tankModel.BulletType, bulletTransform, bulletRotation);
        }

        public void TakeDamage(float damage)
        {
            if (tankModel.GetCurrentHealth() > 0)
            {
                tankModel.SetCurrentHealth(GetCurrentHealth() - damage);
            }
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }
    }
}