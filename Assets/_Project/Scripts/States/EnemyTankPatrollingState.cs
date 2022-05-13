using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyTankPatrollingState : EnemyTankBaseState
{
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        //Debug.Log("Enemy Tank Patrolling State...");
        EnemyPatrol(enemyTankStateManager);
    }
    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {
        if(enemyTankStateManager.agent.remainingDistance <= enemyTankStateManager.agent.stoppingDistance)
        {
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }

        if (enemyTankStateManager.distToPlayer < enemyTankStateManager.chaseRange)
        {
            enemyTankStateManager.SwitchState(enemyTankStateManager.chaseState);
        }
    }

    void EnemyPatrol(EnemyTankStateManager enemyTankStateManager)
    {
        Transform wayPointsObject = GameObject.FindGameObjectWithTag("WayPoint").transform;

        foreach (Transform wP in wayPointsObject)
        {
            enemyTankStateManager.wayPoints.Add(wP);
            enemyTankStateManager.agent.SetDestination(enemyTankStateManager.wayPoints[UnityEngine.Random.Range(0, enemyTankStateManager.wayPoints.Count)].position);
        }
    }
}
