using System.Collections;
using System.Collections.Generic;
using Tanks.tank;
using UnityEngine;

public class EnemyAttackState : EnemyStates
{
    private EnemyView enemyView;
    private EnemyController enemyController;
    public EnemyAttackState()
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

    }
    public override Enemystate GetState()
    {
        return Enemystate.AttackState;
    }
}
