using System;
using UnityEngine;

public class EnemyTankController : TankController
{

    EnemyTankModel EnemyTankModel;
    EnemyTankView EnemyTankView;

    public EnemyTankController(EnemyTankModel enemyTankModel, EnemyTankView enemyTankViewPrefab) : base(enemyTankModel, enemyTankViewPrefab)
    {

        EnemyTankModel = (EnemyTankModel)TankModel;
        EnemyTankView = (EnemyTankView)TankView;

        EnemyTankView.EnemyTankController = this;
    }

    public void FixedUpdate()
    {
        float horizontal = UnityEngine.Random.Range(-1f, 1f);
        float vertical = UnityEngine.Random.Range(-1f, 1f);

        if (horizontal >= .2f || horizontal <= -.2f || vertical >= .2f || vertical <= -.2f)
            handleMovement(horizontal, vertical, Time.fixedDeltaTime);
    }
}