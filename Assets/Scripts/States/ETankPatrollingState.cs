using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ETankPatrollingState : ETankBaseState
{
    public override void EnterState(ETankStateManager enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Patrolling State...");
        EnemyPatrol(enemyTankStateManager);
    }
    public override void UpdateState(ETankStateManager enemyTankStateManager)
    {
        if (enemyTankStateManager.agent.remainingDistance <= enemyTankStateManager.agent.stoppingDistance)
        {
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }

        if (enemyTankStateManager.distToPlayer < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    void EnemyPatrol(ETankStateManager enemyTankStateManager)
    {
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoint").transform;

        foreach (Transform wP in wayPointsObject)
        {
            enemyTankStateManager.wayPoints.Add(wP);
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }
    }
}