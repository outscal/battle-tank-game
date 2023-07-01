
using UnityEngine;

public class EnemyTankController 
{
    public EnemyTankModel tankModel;
    public EnemyTankView tankView;
    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<EnemyTankView>(tankView);
        tankModel.SetEnemyTankController(this);
        tankView.SetEnemyTankController(this);
    }

}
