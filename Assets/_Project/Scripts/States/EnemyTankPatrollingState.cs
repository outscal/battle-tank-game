using UnityEngine;

public class EnemyTankPatrollingState : EnemyTankBaseState
{
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        Debug.Log("Enemy Tank Patrolling State...");
    }

    public override void onCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    {

    }

    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        // if player near enemy chase Range
        //enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        //return;
        
        //EnemyPatrol();
    }


    void EnemyPatrol()
    {

    }
}
