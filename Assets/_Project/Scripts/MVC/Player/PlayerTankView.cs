using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : MonoBehaviour, IDamageable
    {
        private PlayerTankController playerTankController;
        private float movement;
        private float rotate;
        private Rigidbody rb;
        [SerializeField] private List<MeshRenderer> tankBody;
        private float nextShootTime;
        [SerializeField] private Transform bulletTransform;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            nextShootTime = 0.0f;
        }

        private void Start()
        {
            Camera cam = FindObjectOfType<Camera>();
            cam.transform.SetParent(transform);
            cam.transform.position = new Vector3(gameObject.transform.position.x, 3f, -4f);

            playerTankController.UpdateTankColor(tankBody);
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

            if(playerTankController.GetCurrentHealth() <= 0)
            {
                DestroyGameObject();
            }

            if (Input.GetKeyDown(KeyCode.Space)  && Time.time > nextShootTime)
            {
                nextShootTime = Time.time + 1.5f / playerTankController.GetFireRate();
                playerTankController.SpawnBullet(bulletTransform, this.transform.rotation);
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
            Destroy(gameObject);
        }

        public void SetTankController(PlayerTankController _playerTankController)
        {
            playerTankController = _playerTankController;
        }

        public Rigidbody GetRigiBody()
        {
            return rb;
        }
    }
}