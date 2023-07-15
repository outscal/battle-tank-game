
using System;
using UnityEngine;

public class EnemyTankController 
{
    public EnemyTankModel tankModel;
    public EnemyTankView tankView;
    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = tankView;
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

    public void ChangeState(EnemyTankState state)
    {
        if (tankView.currentState != null)
        {
            tankView.currentState.OnStateExit();
        }
        tankView.currentState = state;
        tankView.currentState.OnStateEnter();
    }
}
