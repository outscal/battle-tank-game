using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using BulletServices;


namespace TankServices
{
    public class TankService : GenericSingleton<TankService>
    {

        public TankView tankView;
        public BulletService bulletService { get; private set; }


        [Header("Movement Parameters")]
        public float movementspeed;
        public float rotationSpeed;

        [Header("Health Parameters")]
        public float health;

        [Header("Shooting Parameters")]
        public float fireRate;
        public float bulletDamage;

        [Header("Shooting Parameters")]
        public Transform Bullet;
        public Transform BulletShootPoint;


        private void Start()
        {
            CreateTank();

            //tankModel do not have Mono as parent so we have to pass it using contructor's returned object
            //as view has Mono as Parent we can drag drop it via inspector
        }

        public void GetBulletService()
        {
            bulletService = BulletService.instance.gameObject.GetComponent<BulletService>();
        }

        public void CreateTank()
        {
            TankModel tankModel = new TankModel();
            TankController controller = new TankController(tankModel, tankView, this);
            tankModel.SetMovementParameters(movementspeed, rotationSpeed);
            tankModel.SetHealthParameters(health);
            tankModel.SetShootingParameters(fireRate);

        }

    }
}