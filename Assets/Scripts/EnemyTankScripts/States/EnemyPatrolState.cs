using UnityEngine;
public class EnemyPatrolState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.InitializePatrol();
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
    public override void Tick()
    {
        base.Tick();
        enemyView.EnemyPatrol();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enemyView.ChangeState(enemyView.enemyChaseState);
        }
    }
}
