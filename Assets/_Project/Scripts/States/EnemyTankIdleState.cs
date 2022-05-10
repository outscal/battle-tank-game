using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankIdleState : EnemyTankBaseState
{
    float timer;

    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        timer = 0;
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            
        }
    }

    //public override void ExitState(EnemyTankStateManager enemyTankStateManager)
    //{

    //}

    //public override void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    //{

    //}

}
