using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : States
{
    public AttackState attackState;
    public PatrolState patrolState;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override States RunCurrentState()
    {
        ChasePlayer();

        if (patrolState.playerInAttackRange)
        {
            return attackState;
        }
        if (patrolState.playerInAttackRange == false && patrolState.playerInSightRange == false)
        {
            return patrolState;
        }
        else
        {
            return this;
        }
    }

    public void ChasePlayer()
    {
        patrolState.agent.SetDestination(player.position);
    }
}
