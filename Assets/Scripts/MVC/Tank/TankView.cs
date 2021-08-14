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
        public Transform BulletShootPoint;
        private float canFire=0f;

        void Start()
        {
            Debug.Log("tank view created");
        }

        private void Update()
        {
            float rotation = Input.GetAxisRaw("Horizontal");
            float movement = Input.GetAxisRaw("Vertical");
            tankController.TankMovement(movement);
            tankController.TankRotation(rotation);
            ShootBullet();
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
    }
}