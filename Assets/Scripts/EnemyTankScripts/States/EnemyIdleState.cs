using UnityEngine;
public class EnemyIdleState : EnemyState
{
    float timeElapsed;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Enemy idle start");
        timeElapsed = 0f;
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.Log("Enemy idle end");
    }
    public override void Tick()
    {
        base.Tick();
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 2f)
        {
            enemyView.ChangeState(enemyView.enemyPatrolState);
        }
    }
}
