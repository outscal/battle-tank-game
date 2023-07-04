using UnityEngine;
public class EnemyAttackState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.InitializeAttack();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    public override void Tick()
    {
        base.Tick();
        enemyView.EnemyAttack();
    }
}
