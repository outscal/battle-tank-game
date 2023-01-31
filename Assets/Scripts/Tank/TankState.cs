using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankState : MonoBehaviour
{
    protected EnemyView enemyTankView;
    private void Awake()
    {
        enemyTankView = GetComponent<EnemyView>();
    }

    public virtual void OnEnterState()
    { 
        this.enabled = true;
    }
    public virtual void OnExitState() { this.enabled = false; }
  //  public virtual void Tick() { }

}
