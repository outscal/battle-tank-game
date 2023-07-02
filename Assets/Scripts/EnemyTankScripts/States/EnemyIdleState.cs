using UnityEngine;
public class EnemyIdleState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Enemy idle start");
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.Log("Enemy idle end");
    }
    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enemyView.ChangeState(enemyView.enemyPatrolState);
        }
    }
}
