using System.Diagnostics;
using Tanks.tank;
using UnityEngine;

public class EnemyPatrolling : EnemyStates
{

    public override void OnEnterState()
    {
        base.OnEnterState();
        UnityEngine.Debug.Log("Patrolling Enter");
    }
    public override void OnExitState() 
    {
        
    }
    public override void OnUpdateState()
    {
        UnityEngine.Debug.Log("Patrolling Update");
        _EnemyView.Patrol();
    }
    public override Enemystate GetState()
    {
        return Enemystate.PatrolState;
    }
}
