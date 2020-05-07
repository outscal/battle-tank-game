using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Enemy;

public class EnemyPoolService : PoolingService<EnemyController>
{

    private EnemyModel enemyModel;
    private EnemyView enemyPrefab;
    private Vector3 spawnerPos;
    private Quaternion spawnerRotation;
    private int enemyNumber;


    public EnemyController GetEnemy(EnemyModel enemyModel, EnemyView enemyView, Vector3 spawnerPos, Quaternion spawnerRotation, int enemyNumber)
    {
        this.enemyModel = enemyModel;
        this.enemyPrefab = enemyView;
        this.spawnerPos = spawnerPos;
        this.spawnerRotation = spawnerRotation;
        this.enemyNumber = enemyNumber;
        return GetItem();
    }
    protected override EnemyController CreateItem()
    {
        EnemyController enemyController = new EnemyController(enemyModel, enemyPrefab, spawnerPos, spawnerRotation, enemyNumber);

        return enemyController;
    }
}
