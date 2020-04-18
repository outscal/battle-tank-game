using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletServices;

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
        public Transform BulletShootPoint;

        public MeshRenderer[] childs;

        public void SetTankController(TankController _tankController)
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
                tankController.ShootBullet();
            }
        }
        public void ChangeColor()
        {
            if (tankController.tankModel.tankType == TankType.BlueTank)
            {
                for (int i = 0; i < childs.Length; i++)
                {
                    childs[i].material = tankController.tankModel.blueMat;
                }
            }
            else if (tankController.tankModel.tankType == TankType.GreenTank)
            {
                for (int i = 0; i < childs.Length; i++)
                {
                    childs[i].material = tankController.tankModel.greenMat;
                }
            }
            else if (tankController.tankModel.tankType == TankType.RedTank)
            {
                for (int i = 0; i < childs.Length; i++)
                {
                    childs[i].material = tankController.tankModel.redMat;
                }
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<BulletView>() != null)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}