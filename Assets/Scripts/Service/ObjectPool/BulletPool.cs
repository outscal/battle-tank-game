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
        private Transform Spawn;
        public BulletController GetBullet(BulletModel bulletModel, BulletView bulletPrefab, Transform spawn)
        {
            this.bulletModel = bulletModel;
            this.bulletPrefab = bulletPrefab;
            Spawn = spawn;
            return GetItem();
        }
        protected override BulletController CreateItem()
        {
            BulletController enemyController = new BulletController(bulletModel, bulletPrefab, Spawn);
            return enemyController;
        }
    }
}
