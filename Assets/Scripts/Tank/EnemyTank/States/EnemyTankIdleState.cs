using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTankIdleState : EnemyTankState
{

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        ChangeToPetrolState();
    }

    private async void ChangeToPetrolState()
    {
        await Task.Delay(2000);
        tankView.ChangeState(tankView.petrolState);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
