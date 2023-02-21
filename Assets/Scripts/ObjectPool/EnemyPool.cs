using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : ObjectPool<EnemyController>
{
    private EnemyView enemyPrefab;
    private EnemyModel enemyModel;
    private Transform[] Spawn;
    public EnemyController GetTank(EnemyModel enemyModel, EnemyView enemyPrefab, Transform[] patrolDestination)
    {
        this.enemyModel = enemyModel;
        this.enemyPrefab = enemyPrefab;
        Spawn = patrolDestination;
        return GetItem();
    }
    protected override EnemyController CreateItem()
    {
        EnemyController enemyController = new EnemyController(enemyModel,enemyPrefab,Spawn);
        return enemyController;
    }
}
