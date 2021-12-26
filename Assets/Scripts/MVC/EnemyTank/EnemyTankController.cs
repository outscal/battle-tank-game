
using UnityEngine;

public class EnemyTankController
{
    public EnemyTankModel TankModel { get; }
    public EnemyTankView TankView { get; }
     
    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<EnemyTankView>(tankPrefab);
    }

}
