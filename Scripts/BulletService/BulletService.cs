using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using TankServices;

namespace BulletServices
{
    public class BulletService : GenericSingleton<BulletService>
    {
        public BulletView bulletView;
        public TankService tankService { get; private set; }

        public float bulletDamage;
        public float bulletSpeed;

        private void Start()
        {
            CreateBullet();
            GetTankService();
        }

        public void CreateBullet()
        {
            BulletModel bulletModel = new BulletModel(bulletSpeed, bulletDamage, TankService.instance.Bullet);
            BulletController bulletController = new BulletController(bulletView, bulletModel, this);
        }

        private void GetTankService()
        {
            tankService = TankService.instance.gameObject.GetComponent<TankService>();
        
        }

    }
}
