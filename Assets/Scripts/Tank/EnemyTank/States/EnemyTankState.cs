using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankView))]
public class EnemyTankState : MonoBehaviour
{
    protected EnemyTankView tankView;
    protected EnemyTankController tankController;
    protected EnemyTankModel tankModel;
    private void Awake()
    {
        tankView = GetComponent<EnemyTankView>();
    }
    private void Start()
    {
        tankController = tankView.EnemyTankController;
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
