using BattleTank.EnemyTank;
using BattleTank.GenericObjectPool;
using UnityEngine;

namespace BattleTank.Services.ObjectPoolService
{
    public class EnemyTankPoolService : GenericObjectPool<EnemyTankView>
    {
        [SerializeField] private EnemyTankView tankPrefab;
        [SerializeField] private int poolSize;

        protected override void SetItemPrefab()
        {
            itemPrefab = tankPrefab;
        }

        protected override void SetInitialPoolSize()
        {
            initialPoolSize = poolSize;
        }
    }
}