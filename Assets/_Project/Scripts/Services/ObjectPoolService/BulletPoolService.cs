using BattleTank.Bullet;
using BattleTank.GenericObjectPool;
using UnityEngine;

namespace BattleTank.Services.ObjectPoolService
{
    public class BulletPoolService : GenericObjectPool<BulletView>
    {
        [SerializeField] private BulletView bulletPrefab;
        [SerializeField] private int poolSize;
        
        protected override void SetItemPrefab()
        {
            itemPrefab = bulletPrefab;
        }

        protected override void SetInitialPoolSize()
        {
            initialPoolSize = poolSize;
        }
    }
}