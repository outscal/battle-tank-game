using UnityEngine;
public class EnemyAttackState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Enemy attack start");
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.Log("Enemy attack end");
    }
    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enemyView.ChangeState(enemyView.enemyIdleState);
        }
    }
}
