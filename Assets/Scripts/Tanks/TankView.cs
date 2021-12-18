using UnityEngine;
using BulletServices;
using UnityEngine.Rendering.PostProcessing;

namespace TankServices
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private float movement, rotation;
        private Rigidbody rb;
        public float canFire;
        public Transform bulletShootPoint;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        public void SetTankController(TankController tankControl)
        {
            tankController = tankControl;
        }

        private void Update()
        {
            Move();
            ShootBullet();
        }

        private void FixedUpdate()
        {
            //tankController.Move(movement, tankController.TankModel.MovSpeed);
            //tankController.Rotate(rotation, tankController.TankModel.RotSpeed);

            Vector3 move = transform.forward * movement * tankController.tankModel.MovSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + move);

            float rotate = rotation * tankController.tankModel.RotSpeed * Time.deltaTime;
            Quaternion turn = Quaternion.Euler(0f, rotate, 0f);
            rb.MoveRotation(rb.rotation * turn);
            TankService.Instance.getPlayerPos(transform);
        }

        private void Move()
        {
            movement = Input.GetAxis("Vertical");
            rotation = Input.GetAxis("Horizontal");
        }

        private void ShootBullet()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (canFire < Time.time)
                {
                    canFire = tankController.tankModel.FireRate + Time.time;
                    Shoot();
                }
            }
        }

        public void Shoot()
        {
            BulletService.Instance.CreateBullet(bulletShootPoint.position, transform.rotation, tankController.tankModel.BulletType);
        }

        public void destroyView()
        {
            tankController = null;
            bulletShootPoint = null;
            Destroy(this.gameObject);
        }
    }
}
