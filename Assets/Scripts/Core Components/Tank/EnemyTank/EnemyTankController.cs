using System;
using UnityEngine;

public class EnemyTankController : TankController
{

    EnemyTankModel EnemyTankModel;
    EnemyTankView EnemyTankView;

    float nextDirectionUpdateInterval;
    float horizontal, vertical;

    public EnemyTankController(EnemyTankScriptableObject enemyTankScriptableObject) : base((TankScriptableObject)enemyTankScriptableObject)
    {

        EnemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
        TankModel = (TankModel)EnemyTankModel;

        EnemyTankView = GameObject.Instantiate<EnemyTankView>(EnemyTankModel.EnemyTankViewPrefab);
        TankView = (TankView)EnemyTankView;

        EnemyTankView.EnemyTankController = this;
        TankView.TankController = (TankController)this;

        nextDirectionUpdateInterval = UnityEngine.Random.Range(EnemyTankModel.SpawnChance / 2, EnemyTankModel.SpawnChance + 1);
    }

    public void FixedUpdate()
    {
        nextDirectionUpdateInterval -= Time.fixedDeltaTime;

        if (nextDirectionUpdateInterval <= 0)
        {
            ResetDirection();
        }

        // move only if movement speed is minimum required
        if (horizontal >= .2f || horizontal <= -.2f || vertical >= .2f || vertical <= -.2f)
            HandleMovement(horizontal, vertical, Time.fixedDeltaTime);
    }

    public void OnCollisionEnter(Collision collision)
    {
        ResetDirection();
    }

    void ResetDirection()
    {
        // using random function to generate a random direction
        // Tank moves in random direction and this changes every x random seconds
        // or if tank collides with any objects
        horizontal = UnityEngine.Random.Range(-1f, 1f);
        vertical = UnityEngine.Random.Range(-1f, 1f);

        nextDirectionUpdateInterval = UnityEngine.Random.Range(EnemyTankModel.SpawnChance / 2, EnemyTankModel.SpawnChance + 1);
    }
}