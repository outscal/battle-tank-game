using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTankIdleState : EnemyTankState
{
    private CancellationTokenSource cancellationTokenSource;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        cancellationTokenSource = new CancellationTokenSource();
        ChangeToPetrolState();
    }

    private async void ChangeToPetrolState()
    {
            await Task.Delay(2000, cancellationTokenSource.Token);
            tankView.ChangeState(tankView.petrolState);
        
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        cancellationTokenSource.Cancel();

    }
}
