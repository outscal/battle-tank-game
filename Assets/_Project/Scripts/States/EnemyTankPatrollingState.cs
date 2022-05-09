using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTankPatrollingState : EnemyTankBaseState
{
    //float timer;
    //EnemyTankStateManager EnemyTankStateManager;

    float chaseRange = 10f;
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        //timer = 0;
        Debug.Log("Enemy Tank Patrolling State...");
        enemyTankStateManager.player = GameObject.FindGameObjectWithTag("Player").transform;
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoint").transform;
        foreach (Transform wP in wayPointsObject)
        {
            enemyTankStateManager.wayPoints.Add(wP);
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[0].position);
        }
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        if(enemyTankStateManager.agent.remainingDistance <= enemyTankStateManager.agent.stoppingDistance)
        {
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }

        float distToPlayer = Vector3.Distance(enemyTankStateManager.gameObject.transform.position, enemyTankStateManager.player.transform.position);

        if (distToPlayer < chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }

        //if(timer > 10)
        //{

        //}
        // if player near enemy chase Range
        //enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        //return;

        //EnemyPatrol();
    }

    public override void ExitState(EnemyTankStateManager enemyTankStateManager)
    {
        
    }

    public override void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    {
        
    }



    void EnemyPatrol()
    {
        
    }
}
