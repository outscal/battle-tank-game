using System.Collections;
using System.Collections.Generic;
using Tanks.tank;
using UnityEngine;

public class EnemyChaseState : EnemyStates
{
    private EnemyView enemyView;
    private EnemyController enemyController;
    public EnemyChaseState()
    {
        this.enemyController = _EnemyController;
        this.enemyView = _EnemyView;
    }
    public override void OnEnterState()
    {

    }
    public override void OnExitState()
    {

    }
    public override void OnUpdateState()
    {
        _EnemyController.Chase();
    }
    public override Enemystate GetState()
    {
        return Enemystate.ChaseState;
    }
}
