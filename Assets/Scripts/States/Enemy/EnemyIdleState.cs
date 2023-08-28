using System;
using Tanks.tank;
using UnityEngine;

public class EnemyIdleState : EnemyStates
{

    public override void OnEnterState()
    {

    }
    public override void OnExitState()
    {

    }
    public override void OnUpdateState()
    {
       // _EnemyController.Idle();
    }
    public override Enemystate GetState()
    {
        return Enemystate.IdleState;
    }
}
