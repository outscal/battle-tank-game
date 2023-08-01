using UnityEngine;

public class EnemyTankService : TankService<EnemyTankService>
{

    [SerializeField]
    protected EnemyTankView EnemyTankViewPrefab;

    protected override void Initialize()
    {
        TankModel = new EnemyTankModel(tankSpeed, tankHealth);
        TankController = new EnemyTankController((EnemyTankModel)TankModel, EnemyTankViewPrefab);
    }
}