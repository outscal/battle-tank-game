using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    public EnemyTankModel Enemy_TankModel { get; }
    public EnemyTankView Enemy_TankView { get; }
    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankPrefab)
    {
        Enemy_TankModel = enemyTankModel;
        Enemy_TankView = GameObject.Instantiate<EnemyTankView>(enemyTankPrefab);
    }
}
