using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;

public class TankPoolService : PoolingService<TankPoolService>
{

    private EnemyView enemyPrefab;
    private EnemyModel tankModel;

    protected override TankPoolService CreateItem()
    {
        return base.CreateItem();

        //EnemyController enemyController = new EnemyController(tankModel, )
    }
}
