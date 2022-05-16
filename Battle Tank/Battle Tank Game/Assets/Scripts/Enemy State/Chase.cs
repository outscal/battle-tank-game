using System;
using UnityEngine;

public class Chase : EnemyStatesMachine
{
   public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyView.activeState = State.Chase;
    }

    private void Update()
    {
        if(EnemyView.playerInSightRange && EnemyView.playerInAttackRange)
        {
            EnemyView.currentState.ChangeState(EnemyView.AttackState);
        }
        if(!EnemyView.playerInSightRange && !EnemyView.playerInAttackRange)
        {
            EnemyView.currentState.ChangeState(EnemyView.PatrolState);
        }

        ChasePlayer();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void ChasePlayer()
    {
        if(!EnemyView.playerTransform)
        {
            EnemyView.currentState.ChangeState(EnemyView.PatrolState);
            return;
        }
        EnemyView.agent.SetDestination(EnemyView.playerTransform.position);     
    }
}
