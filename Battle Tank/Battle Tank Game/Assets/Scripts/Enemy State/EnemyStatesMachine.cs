using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStatesMachine : MonoBehaviour
{
    protected EnemyTankView EnemyView;
    
    protected virtual void Awake()
    {
        EnemyView = GetComponent<EnemyTankView>();
    }
    protected virtual void Start()
    {   
        
    }

    public virtual void OnStateEnter()
    {
        this.enabled = true;
    }
    
    public virtual void OnStateExit()
    {
        this.enabled = false;
    }
    
    public void ChangeState(EnemyStatesMachine _state)
    {
        if(EnemyView.currentState != null)
        {
            EnemyView.currentState.OnStateExit();
        }

        EnemyView.currentState = _state;
        EnemyView.currentState.OnStateEnter();
    }    
}
