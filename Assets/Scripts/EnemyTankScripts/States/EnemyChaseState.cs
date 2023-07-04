using UnityEngine;
public class EnemyChaseState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.InitializeChase();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    public override void Tick()
    {
        base.Tick();
        enemyView.EnemyChase();
    }
}
