using BattleTank.Interface;
using BattleTank.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank.PlayerTank
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : MonoBehaviour, IDamageable
    {
        private PlayerTankController playerTankController;
        private float movement;
        private float rotate;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private List<MeshRenderer> tankRenderer;
        private float nextShootTime;
        private float additionalAttackTime;
        [SerializeField] private Transform bulletTransform;
        
        private void Start()
        {
            CameraService.Instance.AttachIntoPlayer(gameObject.transform);
            nextShootTime = 0.0f;
            additionalAttackTime = 1.5f;

            playerTankController.UpdateTankColor(tankRenderer);
        }

        private void Update()
        {
            Movement();

            if (movement != 0)
            {
                playerTankController.Move(movement);
            }

            if (rotate != 0)
            {
                playerTankController.Rotate(rotate);
            }
            
            if (Input.GetKeyDown(KeyCode.Space)  && Time.time > nextShootTime)
            {
                nextShootTime = Time.time + additionalAttackTime / playerTankController.GetFireRate();
                playerTankController.SpawnBullet(bulletTransform, gameObject.transform.rotation);
            }
        }

        private void Movement()
        {
            movement = Input.GetAxisRaw("VerticalUI");
            rotate = Input.GetAxisRaw("HorizontalUI");
        }

        public void Damage(float damage)
        {
            playerTankController.TakeDamage(damage);
        }

        public void DestroyGameObject()
        {
            CameraService.Instance.DetachFromPlayer();
            ParticleEffectsService.Instance.ShowTankExplosionEffect(gameObject.transform.position);
            DestructionService.Instance.DestroyEverything();
            StartCoroutine(DestroyTank());
        }

        IEnumerator DestroyTank()
        {
            yield return new WaitForSeconds(playerTankController.GetTankDestryTime());
            Destroy(gameObject);
        }

        public void SetTankController(PlayerTankController _playerTankController)
        {
            playerTankController = _playerTankController;
        }

        public Rigidbody GetRigiBody()
        {
            return rigidBody;
        }
    }
}