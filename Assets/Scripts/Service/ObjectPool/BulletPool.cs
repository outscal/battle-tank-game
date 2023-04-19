using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.Service;
namespace Tanks.ObjectPool
{
    public class BulletPool : ObjectPool<BulletController>
    {
        private BulletView bulletPrefab;
        private BulletModel bulletModel;
        //private BulletObject bullet;
        private Transform Spawn;
        public BulletController GetBullet(BulletObject bullet, Transform spawn)
        {
            bulletModel = new BulletModel(bullet);
            this.bulletPrefab = bullet.bulletView;
            Spawn = spawn;
            return GetItem();
        }
        protected override BulletController CreateItem()
        {
            BulletController bulletController = new BulletController(bulletModel, bulletPrefab, Spawn);
            return bulletController;
        }
    }
}
