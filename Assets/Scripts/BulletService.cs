using UnityEngine;
using Singleton;

namespace Weapons
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        [SerializeField]
        private BulletController bulletPrefab;

        public BulletController CreateBullet()
        {
            BulletController createdBullet = Instantiate(bulletPrefab);
            return createdBullet;
        }
    }
}
