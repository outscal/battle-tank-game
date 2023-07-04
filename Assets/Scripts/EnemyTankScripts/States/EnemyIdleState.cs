using UnityEngine;
public class EnemyIdleState : EnemyState
{
    float timeElapsed;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        timeElapsed = 0f;
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
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
