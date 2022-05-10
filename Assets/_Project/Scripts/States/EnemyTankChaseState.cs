using UnityEngine;

public class EnemyTankChaseState : EnemyTankBaseState
{
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        Debug.Log("Enemy Tank Chase State...");
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.player.position);
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        EnemyAttack(enemyTankStateManager);
        EnemyPatrol(enemyTankStateManager);
    }

    private void EnemyAttack(EnemyTankStateManager enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer <= enemyTankStateManager.attackRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.attackState);
        }
    }
    private void EnemyPatrol(EnemyTankStateManager enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.patrollingState);
        }
    }
    //public override void ExitState(EnemyTankStateManager enemyTankStateManager)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    //{
    //    throw new System.NotImplementedException();
    //}
}
