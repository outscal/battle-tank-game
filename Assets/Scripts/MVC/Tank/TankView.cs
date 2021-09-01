using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class handles the tankview logic 
    /// it inherits Monobehaviours
    /// </summary>
    public class TankView : MonoBehaviour, IDamagable
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
        //tank movement
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
        //triggered after tank distroyed
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
        //player tank will take damage
        public void TakeDamage(int damage)
        {
            tankController.ApplyDamage(damage);
        }
    }
}