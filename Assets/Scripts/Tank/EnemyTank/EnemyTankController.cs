using System;
using UnityEngine;

public class EnemyTankController : TankController
{

    EnemyTankModel EnemyTankModel;
    EnemyTankView EnemyTankView;

    public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankViewPrefab) : base(_enemyTankModel, _enemyTankViewPrefab)
    {

        EnemyTankModel = (EnemyTankModel)TankModel;
        EnemyTankView = (EnemyTankView)TankView;

        EnemyTankView.EnemyTankController = this;
    }

    public void FixedUpdate()
    {
        float horizontal = UnityEngine.Random.Range(.01f, 2f);
        horizontal = horizontal >= .2f || horizontal <= -.2f ? horizontal : 0;
        float vertical = UnityEngine.Random.Range(.01f, 2f);
        vertical = vertical >= .2f || vertical <= -.2f ? vertical : 0;

        Vector3 position = EnemyTankView.Position;
        position.x += horizontal * EnemyTankModel.Speed * Time.fixedDeltaTime;
        position.z += vertical * EnemyTankModel.Speed * Time.fixedDeltaTime;

        Vector3 rotation = new Vector3(horizontal, position.y, vertical);

        EnemyTankView.Rotation = Quaternion.LookRotation(rotation);
        EnemyTankView.Position = position;
    }
}