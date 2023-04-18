using BattleTank.Enum;
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
        [SerializeField] private float nextShootTime;
        [SerializeField] private float additionalAttackTime;
        [SerializeField] private Transform bulletTransform;
        [SerializeField] private GameObject arrowObject;
        [SerializeField] private float arrowObjectXAxis;
        
        private void Start()
        {
            CameraService.Instance.AttachIntoPlayer(gameObject.transform);

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
                playerTankController.SpawnBullet(bulletTransform, transform.rotation);
            }

            if (arrowObject.activeSelf)
            {
                arrowObject.transform.LookAt(CollectibleService.Instance.GetCollectibleObjectTransform());
                arrowObject.transform.rotation = Quaternion.Euler(new Vector3(arrowObjectXAxis, arrowObject.transform.rotation.eulerAngles.y, arrowObject.transform.rotation.eulerAngles.z));
            }
        }

        private void Movement()
        {
            movement = Input.GetAxisRaw("VerticalUI");
            rotate = Input.GetAxisRaw("HorizontalUI");
        }

        public void Damage(TankID shooter, float damage)
        {
            playerTankController.TakeDamage(damage);
        }

        public void DestroyGameObject()
        {
            CameraService.Instance.DetachFromPlayer();
            ParticleEffectsService.Instance.ShowExplosionEffect(ExplosionType.TankExplosion, gameObject.transform.position);
            SoundService.Instance.PlayEffects(Sounds.TankExplosion);
            DestructionService.Instance.DestroyEverything();
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

        public TankID GetTankID()
        {
            return TankID.Player;
        }

        public void AddAdditionalHealth(float additionalHealthPercentage)
        {
            playerTankController.AddAdditionalHealth(additionalHealthPercentage);
        }

        public void SetArrowObjectActive(bool _value)
        {
            arrowObject.SetActive(_value);
        }
    }
}