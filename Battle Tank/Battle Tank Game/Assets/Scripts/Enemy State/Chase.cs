using System;
using UnityEngine;

public class Chase : State
{
    Vector3 Direction;
   public override void OnStateEnter(EnemyStatesMachine _EnemyStates)
    {
        _EnemyStates.currentState = this;
        _EnemyStates.playerTransform = GameObject.FindObjectOfType<TankView>().transform;        
    }

    public override void OnUpdate(EnemyStatesMachine _EnemyStates)
    {
        if(_EnemyStates.playerInSightRange && _EnemyStates.playerInAttackRange)
        {
            _EnemyStates.ChangeState(_EnemyStates.AttackState);
        }
        if(!_EnemyStates.playerInSightRange && !_EnemyStates.playerInAttackRange)
        {
            _EnemyStates.ChangeState(_EnemyStates.PatrolState);
        }

        Direction = _EnemyStates.playerTransform.position - _EnemyStates.transform.position;        
        Quaternion rotation = Quaternion.LookRotation(Direction);
        _EnemyStates.transform.rotation = rotation;
        
        ChasePlayer(_EnemyStates);
    }

    public override void OnStateExit(EnemyStatesMachine _EnemyStates)
    {
        _EnemyStates.agent.SetDestination(_EnemyStates.transform.position);   
    }

    private void ChasePlayer(EnemyStatesMachine _EnemyStates)
    {
         
         
        _EnemyStates.agent.SetDestination(_EnemyStates.playerTransform.position);
    }
}
