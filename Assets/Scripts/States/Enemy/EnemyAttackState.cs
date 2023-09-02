
using Tanks.tank;
using UnityEngine;

public class EnemyAttackState : EnemyStates
{

    [SerializeField]
    private float timer;
    [SerializeField]
    private float delay;

    public override void OnEnterState()
    {
        UnityEngine.Debug.Log("Attacking Enter");
        timer = 0f;
    }
    public override void OnExitState()
    {

    }
    public override void OnUpdateState()
    {
      timer= _EnemyView.Attack(timer,delay);
    }
    public override Enemystate GetState()
    {
        return Enemystate.AttackState;
    }
}
