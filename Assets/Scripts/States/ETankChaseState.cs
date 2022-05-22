using UnityEngine;

public class ETankChaseState : ETankBaseState
{
    public override void EnterState(ETankStateManager enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Chase State...");
    }
    public override void UpdateState(ETankStateManager enemyTankStateManager)
    {
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.player.position);
        CheckEnemyAttack(enemyTankStateManager);
        CheckEnemyPatrol(enemyTankStateManager);
    }

    private void CheckEnemyAttack(ETankStateManager enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer <= enemyTankStateManager.attackRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.attackState);
        }
    }
    private void CheckEnemyPatrol(ETankStateManager enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.patrollingState);
        }
    }
}