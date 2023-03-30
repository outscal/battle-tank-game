using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class PlayerTankController
    {
        private TankModel tankModel;
        private PlayerTankView playerTankView;

        private float currentHealth;

        private Rigidbody rb;
        
        public PlayerTankController(TankModel _tankModel, PlayerTankView _playerTankView, Transform position)
        {
            tankModel = _tankModel;
            playerTankView = GameObject.Instantiate<PlayerTankView>(_playerTankView, position);

            currentHealth = tankModel.health;
            rb = playerTankView.GetRigiBody();

            playerTankView.SetTankController(this);
        }
        
        public Transform GetPlayerTransform()
        {
            return playerTankView.transform;
        }

        public void Move(float movement)
        {
            rb.velocity = playerTankView.transform.forward * movement * tankModel.movementSpeed;
        }

        public void Rotate(float rotation)
        {
            Vector3 vector = new Vector3(0f, rotation * tankModel.rotationSpeed, 0f);     // Rotating full TankBody
            Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }

        public void UpdateTankColor(List<MeshRenderer> tankBody)
        {
            for(int i = 0; i < tankBody.Count; i++)
            {
                tankBody[i].material = tankModel.material;
            }
        }

        public float GetFireRate()
        {
            return tankModel.fireRate;
        }

        public void SpawnBullet(Transform bulletTransform, Quaternion quaternion)
        {
            BulletService.Instance.SpawnBullet(tankModel.BulletType, bulletTransform, quaternion);
        }

        public void TakeDamage(float damage)
        {
            if (tankModel.GetCurrentHealth() > 0)
            {
                float remainingHealth = GetCurrentHealth() - damage;
                tankModel.SetCurrentHealth(remainingHealth);
            }
        }

        public float GetCurrentHealth()
        {
            return tankModel.GetCurrentHealth();
        }
    }
}