using UnityEngine;

public class Patrol : EnemyStatesMachine
{ 
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyView.activeState = State.Patrol;   
    }

    protected override void Start()
    {
        base.Start();
        ChangeWalkPoint();
    }
    private void Update()
    {
        if(EnemyView.playerInSightRange && !EnemyView.playerInAttackRange)
        {
            EnemyView.currentState.ChangeState(EnemyView.ChaseState);
        }
        if(EnemyView.playerInSightRange && EnemyView.playerInAttackRange)
        {
            EnemyView.currentState.ChangeState(EnemyView.AttackState);
        }

        Patrolling();   
    }

    public void ChangeWalkPoint()
    {
        while(true)
        {
            //await new WaitForSeconds(EnemyView.patrolTime);
            EnemyView.walkPointSet = false;
        }
    }

    
    private void Patrolling()
    {
        if(!EnemyView.walkPointSet)
            SearchWalkPoint();

        if(EnemyView.walkPointSet)
            EnemyView.agent.SetDestination(EnemyView.walkPoint);
        
        Vector3 distanceToWalkPoint = EnemyView.transform.position - EnemyView.walkPoint;

        //walkpoint reached 
        if(distanceToWalkPoint.magnitude < 1f)
            EnemyView.walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = UnityEngine.Random.Range(-EnemyView.walkPointRange, EnemyView.walkPointRange);
        float randomX = UnityEngine.Random.Range(-EnemyView.walkPointRange, EnemyView.walkPointRange);

        EnemyView.walkPoint = new Vector3(EnemyView.transform.position.x + randomX, EnemyView.transform.position.y, EnemyView.transform.position.z + randomZ);

        if(Physics.Raycast(EnemyView.walkPoint, -EnemyView.transform.up, 2f, EnemyView.whatIsGround))
            EnemyView.walkPointSet = true;
    }
}



    