using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyTankView))]
public class EnemyStates : MonoBehaviour
{
    protected EnemyTankView enemyTankView;
    protected EnemyTankModel enemyTankModel;
    private void Awake()
    {
        enemyTankView = GetComponent<EnemyTankView>();
    }
    protected virtual void Start()
    {
        enemyTankModel = enemyTankView.enemyTankController.TankModel;
    }
    public virtual void OnEnterState()
    {
        this.enabled = true;
    }

    public virtual void OnExitState()
    {
        this.enabled = false;
    }


}
