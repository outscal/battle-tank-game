using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Bullet.BulletTypes;
using Interfaces;
using System;
using Audio;

public enum BulletType { slow, medium, fast }

namespace Bullet
{
    public class BulletManager : IBullet
    {
        [SerializeField]
        private BulletType bulletType = BulletType.medium;

        public event Action<AudioName> BulletSpawnEvent;

        public BulletType Bullet_Type
        {
            get { return bulletType; }
        }

        public BulletManager()
        {
            bulletType = BulletType.fast;
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

            BulletSpawnEvent?.Invoke(AudioName.Fire);
            return bulletController;
        }

        public void DestroyBullet(BulletController _bulletController)
        {
            _bulletController = null;
        }

        public void OnUpdate()
        {

        }

    }
}