using System;
using UnityEngine;

public class EnemyTankController : TankController
{

    EnemyTankModel EnemyTankModel;
    EnemyTankView EnemyTankView;

    public EnemyTankController(EnemyTankScriptableObject enemyTankScriptableObject) : base((TankScriptableObject)enemyTankScriptableObject)
    {

        EnemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
        TankModel = (TankModel)EnemyTankModel;

        EnemyTankView = GameObject.Instantiate<EnemyTankView>(EnemyTankModel.EnemyTankViewPrefab);
        TankView = (TankView)EnemyTankView;

        EnemyTankView.EnemyTankController = this;
    }

    public void FixedUpdate()
    {
        float horizontal = UnityEngine.Random.Range(-1f, 1f);
        float vertical = UnityEngine.Random.Range(-1f, 1f);

        if (horizontal >= .2f || horizontal <= -.2f || vertical >= .2f || vertical <= -.2f)
            HandleMovement(horizontal, vertical, Time.fixedDeltaTime);
    }
}