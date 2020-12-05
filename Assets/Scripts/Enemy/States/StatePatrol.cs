using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StatePatrol : EnemyTankState
{
    private Vector3 m_startingPosition;
    private Vector3 m_roamPosition;
    private float m_tolerance = 2f;

    [SerializeField]private NavMeshAgent agent;
    private Coroutine m_roamAround;
 
//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("enemy Patrol state Enter-------->");

        m_startingPosition = transform.position;
        m_roamPosition = GetRoamingPosition();
        m_roamAround = StartCoroutine(RoamAround());
    }

    public override void OnExitState()
    {
        base.OnExitState();
        Debug.Log("enemy Patrol state Exit-------->");
        StopCoroutine(m_roamAround);
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private IEnumerator RoamAround(){
        while (true)
        {
            agent.SetDestination(m_roamPosition);
            if(Vector3.Distance(transform.position,m_roamPosition)<m_tolerance){
                m_roamPosition = GetRoamingPosition();
            }
            yield return null;
        }
    }

//`````````````````````````````````````````````````````````````````````````````````````````````````````
//`````````````````````````````````````````````````````````````````````````````````````````````````````

    private Vector3 GetRoamingPosition(){
        Vector3 _randDirection = new Vector3 (Random.Range(-1f,1f),0f,Random.Range(-1f,1f));
        Vector3 _randRoamPosition =  m_startingPosition + _randDirection * Random.Range(5f,8f);
        return  _randRoamPosition;
    }



}
