using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace TankServices
{
    public class TankView : MonoBehaviour
    {
        //references
        private TankController tankController;

        //floats
        private float rotation;
        private float movement;
        private float canFire = 0f;

        private void Start()
        {
            Debug.Log("Tank View is Created", this);
        }

        public void GetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        private void Update()
        {
            Movement();
            ShootBullet();
        }

        private void Movement()
        {
            Rotation();
            Accelaration();
        }
        private void Rotation()
        {
            rotation = Input.GetAxis("Horizontal");

            if (rotation != 0)
                tankController.Rotate(rotation, tankController.tankModel.rotationSpeed);

        }
        private void Accelaration()
        {
            movement = Input.GetAxis("Vertical");

            if (movement != 0)
                tankController.Move(movement, tankController.tankModel.movementSpeed);
        }

        private void ShootBullet()
        {
            if (Input.GetButton("Fire1") && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;

                Instantiate(tankController.tankService.Bullet.gameObject,
                 tankController.tankService.BulletShootPoint.position,
                 Quaternion.identity);

                tankController.tankService.GetBulletService();
            }
        }

    }

}