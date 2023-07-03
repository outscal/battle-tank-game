using UnityEngine;
public class EnemyPatrolState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        enemyView.InitializePatrol();
        Debug.Log("Enemy patrol start");
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.Log("Enemy patrol end");
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
