using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class handles the tankview logic 
    /// it inherits Monobehaviours
    /// </summary>
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        [SerializeField] private TankType tankType;
        private float movement,rotation;
        public Transform BulletShootPoint;
        private float canFire=0f;
        public MeshRenderer[] childs;

        private void Update()
        {
            Movement();
            ShootBullet();
        }

        private void FixedUpdate()
        {
            tankController.TankMovement(movement, tankController.TankModel.Speed);
            tankController.TankRotation(rotation, tankController.TankModel.rotationSpeed);
        }

        private void Movement()
        {
            rotation = Input.GetAxisRaw("Horizontal");
            movement = Input.GetAxisRaw("Vertical");
        }
        //setting tank controller
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        //shooting for tank
        private void ShootBullet()
        {
            if (Input.GetButtonDown("Fire1") && canFire<Time.time)
            {
                canFire = tankController.TankModel.fireRate + Time.time;
                tankController.ShootBullet();
            }
        }

        public void DestroyView()
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }
            tankController = null;
            BulletShootPoint = null;
            Destroy(this.gameObject);
        }
    }
}