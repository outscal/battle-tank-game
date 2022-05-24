using System;
using UnityEngine;

public class Attack : State
{
    public override void OnStateEnter(EnemyStatesMachine _EnemyStates)
    {
        _EnemyStates.currentState = this;
    }
        
    public override void OnUpdate(EnemyStatesMachine _EnemyStates)
    {
        if(!_EnemyStates.playerInSightRange && !_EnemyStates.playerInAttackRange)
        {
            _EnemyStates.ChangeState(_EnemyStates.PatrolState);
        }

        if(_EnemyStates.playerInSightRange && !_EnemyStates.playerInAttackRange)
        {
            _EnemyStates.ChangeState(_EnemyStates.ChaseState);
        }

        AttackPlayer(_EnemyStates);
    }

    public override void OnStateExit(EnemyStatesMachine _EnemyStates)
    {

    }    

    private void AttackPlayer(EnemyStatesMachine _EnemyStates)
    {
        if(!_EnemyStates.playerTransform)
        {
            _EnemyStates.ChangeState(_EnemyStates.PatrolState);
            return;
        }
       
        _EnemyStates.transform.LookAt(_EnemyStates.playerTransform);

        if(!_EnemyStates.EnemyView.alreadyAttacked)
        {
            _EnemyStates.EnemyView.alreadyAttacked = true;
            _EnemyStates.EnemyView.FireShell();            
            _EnemyStates.CoroutineStart();            
        }
    }   
}
