using Tanks.tank;
using UnityEngine;


public class EnemyChaseState : EnemyStates
{

    public override void OnEnterState()
    {
        UnityEngine.Debug.Log("Chase Enter");
    }
    public override void OnExitState()
    {

    }
    public override void OnUpdateState()
    {
        _EnemyView.Chase();
    }
    public override Enemystate GetState()
    {
        return Enemystate.ChaseState;
    }
}
