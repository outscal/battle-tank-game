using System.Collections;
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

    }
    public override void onCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    {
    }
}
