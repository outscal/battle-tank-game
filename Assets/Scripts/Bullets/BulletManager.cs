using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Bullet.BulletTypes;

public enum BulletType { slow, medium, fast }

namespace Bullet
{
    public class BulletManager : Singleton<BulletManager>
    {
        [SerializeField]
        private BulletType bulletType = BulletType.medium;

        public BulletType Bullet_Type
        {
            get { return bulletType; }
        }

        public BulletController bulletController { get; private set; }


        public BulletController SpawnBullet()
        {
            if (bulletType == BulletType.fast)
                bulletController = new FastBulletController();
            else if (bulletType == BulletType.medium)
                bulletController = new MediumBulletController();
            else if (bulletType == BulletType.slow)
                bulletController = new SlowBulletController();

            return bulletController;
        }

        public void RemoveController(BulletController _bulletController)
        {
            _bulletController = null;
        }
    }
}