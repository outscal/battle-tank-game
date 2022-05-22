using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETankAttackState : ETankBaseState
{
    public override void EnterState(ETankStateManager enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Attack State...");
        enemyTankStateManager.agent.SetDestination(enemyTankStateManager.agent.transform.position);
    }
    public override void UpdateState(ETankStateManager enemyTankStateManager)
    {
        Attackfunction(enemyTankStateManager);
        enemyTankStateManager.agent.transform.LookAt(enemyTankStateManager.player.transform);
        if (enemyTankStateManager.distToPlayer > enemyTankStateManager.attackRange && enemyTankStateManager.attackRange < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    private void Attackfunction(ETankStateManager enemyTankStateManager)
    {
        if (!enemyTankStateManager.isAlreadyAttacked)
        {
            enemyTankStateManager.EnemyTankView.FireFunction();
            enemyTankStateManager.isAlreadyAttacked = true;
            enemyTankStateManager.StartCoroutine(ResetAttack(enemyTankStateManager));
        }
    }

    private IEnumerator ResetAttack(ETankStateManager enemyTankStateManager)
    {
        yield return new WaitForSecondsRealtime(enemyTankStateManager.timeBetweenAttack);
        enemyTankStateManager.isAlreadyAttacked = false;
    }
}