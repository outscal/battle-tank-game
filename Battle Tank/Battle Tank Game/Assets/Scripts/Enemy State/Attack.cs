using System;
using UnityEngine;

public class Attack : EnemyStatesMachine
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyView.activeState = State.Attack;        
    }
        
    private void Update()
    {
        if(!EnemyView.playerInSightRange && !EnemyView.playerInAttackRange)
        {
            EnemyView.currentState.ChangeState(EnemyView.PatrolState);
        }

        if(EnemyView.playerInSightRange && !EnemyView.playerInAttackRange)
        {
            EnemyView.currentState.ChangeState(EnemyView.ChaseState);
        }

        AttackPlayer();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    private void AttackPlayer()
    {
        if(!EnemyView.playerTransform)
        {
            EnemyView.currentState.ChangeState(EnemyView.PatrolState);
            return;
        }

        EnemyView.agent.SetDestination(EnemyView.transform.position);

        EnemyView.transform.LookAt(EnemyView.playerTransform);

        if(!EnemyView.alreadyAttacked)
        {
            EnemyView.alreadyAttacked = true;
            EnemyView.FireShell();            
            //await new WaitForSeconds(EnemyView.timeBetweenAttacks);
            ResetAttack();
        }
    }

    private void ResetAttack()
    {
        EnemyView.alreadyAttacked = false;
    }
}
