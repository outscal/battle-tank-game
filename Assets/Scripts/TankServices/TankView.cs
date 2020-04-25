using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BulletServices;
using VFXServices;

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
        private void FixedUpdate()
        {
            if (movement != 0)
                tankController.Move(movement, tankController.tankModel.movementSpeed);

            if (rotation != 0)
                tankController.Rotate(rotation, tankController.tankModel.rotationSpeed);
        }

        private void Movement()
        {
            rotation = Input.GetAxis("Horizontal");
            movement = Input.GetAxis("Vertical");
        }

        private void ShootBullet()
        {
            if (Input.GetButton("Fire1") && canFire < Time.time)
            {
                canFire = tankController.tankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }
        public void ChangeColor(Material material)
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i].material = material;
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<BulletView>() != null)
            {
                tankController.OnCollisionWithBullet(other.gameObject.GetComponent<BulletView>());
            }
        }
        public void DestroyView()
        {
            for (int i = 0; i < childs.Length; i++)
                childs[i] = null;

            tankController = null;
            BulletShootPoint = null;
            VFXService.instance.TankExplosionEffects(transform.position);
            Destroy(this.gameObject);
        }
    }
}