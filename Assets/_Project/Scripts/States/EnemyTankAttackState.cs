using UnityEngine;

public class EnemyTankAttackState : EnemyTankBaseState
{
    public EnemyTankController EnemyTankController;
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        Debug.Log("Enemy Tank Attack State...");
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.agent.transform.position);
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        enemyTankStateManager.EnemyTankView.FireFunction();
        enemyTankStateManager.agent.transform.LookAt(enemyTankStateManager.player.transform);
        //enemyTankStateManager.EnemyTankView.FireFunction();
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
