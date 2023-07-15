using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankView))]
public class EnemyTankState : MonoBehaviour
{
    protected EnemyTankView tankView;

    private void Awake()
    {
        tankView = GetComponent<EnemyTankView>();
    }
    public virtual void OnStateEnter() 
    { 
        this.enabled = true; 
    }
    public virtual void OnStateExit() 
    { 
        this.enabled = false; 
    }
}
