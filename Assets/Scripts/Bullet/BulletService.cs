using UnityEngine;
using Singleton;
using System.Collections.Generic;

namespace Weapons
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        [SerializeField]
        private BulletController bulletPrefab;

        [SerializeField]
        private int poolSize;
        Queue<BulletController> bulletPool;

        private void Start()
        {
            bulletPool = new Queue<BulletController>();
            for (int i = 0; i < poolSize; i++)
            {
                CreateBulletAndAddToPool();
            }
        }

        private void CreateBulletAndAddToPool()
        {
            BulletController createdBullet = CreateBullet();
            bulletPool.Enqueue(createdBullet);
            createdBullet.gameObject.SetActive(false);
        }

        public BulletController GetBulletFromPool()
        {
            if (bulletPool.Count <= 0)
            {
                CreateBulletAndAddToPool();
            }
            return bulletPool.Dequeue();
        }

        private BulletController CreateBullet()
        {
            BulletController createdBullet = Instantiate(bulletPrefab);
            return createdBullet;
        }

        public void AddBulletToPool(BulletController bullet)
        {
            bulletPool.Enqueue(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
}
