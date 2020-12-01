using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChase : EnemyTankState
{
   [SerializeField]private Transform  target;

   private bool m_followPlayer;

    private float m_duration;
    private float time = 0;

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
            float step =  10f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            if (Vector3.Distance(transform.position, target.position) < 2f){
                m_followPlayer = false;
            }
            yield return null;
        }
        
    }

}
