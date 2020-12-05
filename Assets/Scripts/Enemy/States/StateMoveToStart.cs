using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMoveToStart : EnemyTankState
{
    private EnemyManager enemyManager;
    [SerializeField]private NavMeshAgent agent;

    private Coroutine homeComing;
    
    public override void OnEnterState(){
        base.OnEnterState();
        Debug.Log("enter state HomeComing--------->");
        enemyManager = GetComponent<EnemyManager>();
        agent.SetDestination(enemyManager.startingPosition);
        Debug.Log("starting Position = " + enemyManager.startingPosition);
    }

    public override void OnExitState(){
        base.OnExitState();
        Debug.Log("exit state HomeComing--------->");
    }

}
