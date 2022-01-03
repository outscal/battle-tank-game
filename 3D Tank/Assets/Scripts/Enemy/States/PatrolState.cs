using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolState : States
{
    public ChaseState chaseState;
    public AttackState attackState;

    public NavMeshAgent agent;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public LayerMask whatIsGround;
    public float sightRange;
    public bool playerInSightRange = false;
    public LayerMask whatIsPlayer;

    public float attackRange;
    public bool playerInAttackRange = false;


    public override States RunCurrentState()
    {
        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }

        if (playerInSightRange)
        {
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
            StartCoroutine(StartPatrolling());
        }

        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }   
    }

    private IEnumerator StartPatrolling()
    {
        yield return new WaitForSeconds(5f);
        walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
            //Calculate random point in range
       float randomZ = Random.Range(-58f, 30f);
       float randomX = Random.Range(-41f, 45f);

       walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

       if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
           walkPointSet = true;
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}

