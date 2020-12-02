using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMoveToStart : EnemyTankState
{
    [SerializeField]private Transform StartPosition;
    [SerializeField]private float m_moveSpeed = 10f;

    private Coroutine homeComing;
    
    private bool isgoingToStart;

    public override void OnEnterState(){
        base.OnEnterState();
        Debug.Log("enter state HomeComing--------->");
        homeComing = StartCoroutine(MoveToStart());
    }

    public override void OnExitState(){
        base.OnExitState();
        Debug.Log("exit state HomeComing--------->");
        StopCoroutine(homeComing);
    }

    private IEnumerator MoveToStart(){
        while(isgoingToStart){
            float _step = m_moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,StartPosition.position,_step);
            if(Vector3.Distance(transform.position,StartPosition.position)<2f){
                isgoingToStart = false;
            }
            yield return null;
        }
    }

}
