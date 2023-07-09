using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float timeElapsed;

    [SerializeField] private float timeToWait = 2f;

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

        if (IdleTimeLimitReached())
            enemyView.ChangeState(enemyView.enemyPatrolState);
    }

    private bool IdleTimeLimitReached()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > timeToWait)
            return true;
        else
            return false;
    }
}
