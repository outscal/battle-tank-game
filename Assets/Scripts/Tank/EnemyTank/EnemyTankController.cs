
using System;
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
        this.tankView.SetEnemyTankController(this);
    }

    public void TakeDamage(float power)
    {
        tankModel.health -= power;
        if(tankModel.health<=0)
        {
            TankDestroy();
        }
    }

    private void TankDestroy()
    {
        GameObject.Destroy(tankView.gameObject);
    }
}
