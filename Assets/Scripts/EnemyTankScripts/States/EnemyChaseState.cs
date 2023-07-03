using UnityEngine;
public class EnemyChaseState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Enemy chase start");
        enemyView.InitializeChase();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.Log("Enemy chase end");
    }
    public override void Tick()
    {
        base.Tick();
        enemyView.EnemyChase();
    }
}
