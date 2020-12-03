using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateChase : EnemyTankState
{
   [SerializeField]private Transform  target;
   [SerializeField]private NavMeshAgent agent;

   private bool m_followPlayer;


    public override void OnEnterState()
    {
        base.OnEnterState();
        m_followPlayer = true;
        Debug.Log("enemy Chase state Enter-------->");
        StartCoroutine(chasePlayer());
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("enemy chase state Exit-------->");
    }

    private IEnumerator chasePlayer(){
        while(m_followPlayer){
            agent.SetDestination(target.position);
            m_followPlayer = false;
        }
        yield return null;
    }

}
