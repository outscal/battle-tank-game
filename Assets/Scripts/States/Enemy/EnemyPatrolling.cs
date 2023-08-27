using System.Collections;
using System.Collections.Generic;
using Tanks.tank;
using UnityEngine;

public class EnemyPatrolling : EnemyStates
{
    private EnemyView enemyView;
    private EnemyController enemyController;
    public EnemyPatrolling()
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
        _EnemyController.Patrol();
    }
    public override Enemystate GetState()
    {
        return Enemystate.PatrolState;
    }
}
