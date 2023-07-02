using UnityEngine;
public class EnemyChaseState : EnemyState
{
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Enemy chase start");
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        Debug.Log("Enemy chase end");
    }
    public override void Tick()
    {
        base.Tick();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            enemyView.ChangeState(enemyView.enemyAttackState);
        }
    }
}
