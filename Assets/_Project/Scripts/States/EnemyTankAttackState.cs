using UnityEngine;

public class EnemyTankAttackState : EnemyTankBaseState
{
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        Debug.Log("Enemy Tank Attack State...");
        enemyTankStateManager.agent.transform.LookAt(enemyTankStateManager.player.transform);
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.attackRange && enemyTankStateManager.attackRange < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    //public override void ExitState(EnemyTankStateManager enemyTankStateManager)
    //{
        
    //}

    //public override void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    //{
    //    throw new System.NotImplementedException();
    //}
}
