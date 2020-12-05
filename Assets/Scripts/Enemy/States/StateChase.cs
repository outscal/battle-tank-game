using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateChase : EnemyTankState
{
   [SerializeField]private Transform  target;
   [SerializeField]private NavMeshAgent agent;

   private Coroutine chasing;

   private EnemyManager enemyManager;

    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyManager = GetComponent<EnemyManager>();
        Debug.Log("enemy Chase state Enter-------->");
        chasing = StartCoroutine(chasePlayer());
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("enemy chase state Exit-------->");
        StopCoroutine(chasing);
    }

    private IEnumerator chasePlayer(){
        while(true){
            agent.SetDestination(target.position);
            yield return null;
        }
        
    }

}
