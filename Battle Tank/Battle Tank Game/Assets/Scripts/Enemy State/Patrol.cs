using UnityEngine;

public class Patrol : State
{ 
    public override void OnStateEnter(EnemyStatesMachine _EnemyStates)
    {
        _EnemyStates.currentState = this;
    }
    
    public override void OnUpdate(EnemyStatesMachine _EnemyStates)
    {
        if(_EnemyStates.playerInSightRange && !_EnemyStates.playerInAttackRange)
        {
            _EnemyStates.ChangeState(_EnemyStates.ChaseState);
        }
        
        Patrolling(_EnemyStates);  
    }
    public override void OnStateExit(EnemyStatesMachine _EnemyStates)
    {

    }
        
    private void Patrolling(EnemyStatesMachine _EnemyStates)
    {
        if(!_EnemyStates.walkPointSet)
            SearchWalkPoint(_EnemyStates);

        if(_EnemyStates.walkPointSet)
            _EnemyStates.agent.SetDestination(_EnemyStates.walkPoint);
        
        Vector3 distanceToWalkPoint = _EnemyStates.transform.position - _EnemyStates.walkPoint;

        //walkpoint reached 
        if(distanceToWalkPoint.magnitude < 1f)
            _EnemyStates.walkPointSet = false;
    }

    private void SearchWalkPoint(EnemyStatesMachine _EnemyStates)
    {
        float randomZ = UnityEngine.Random.Range(-_EnemyStates.walkPointRange, _EnemyStates.walkPointRange);
        float randomX = UnityEngine.Random.Range(-_EnemyStates.walkPointRange, _EnemyStates.walkPointRange);

        _EnemyStates.walkPoint = new Vector3(_EnemyStates.transform.position.x + randomX, _EnemyStates.transform.position.y, _EnemyStates.transform.position.z + randomZ);
        
        if(Physics.Raycast(_EnemyStates.walkPoint, -_EnemyStates.transform.up, 5f, _EnemyStates.whatIsGround))
            _EnemyStates.walkPointSet = true;
    }
}



    