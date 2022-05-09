using UnityEngine;

public class EnemyTankChaseState : EnemyTankBaseState
{
    public override void EnterState(EnemyTankStateManager enemyTankStateManager)
    {
        Debug.Log("Enemy Tank Chase State...");

    }

    public override void ExitState(EnemyTankStateManager enemyTankStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(EnemyTankStateManager enemyTankStateManager)
    {

    }
}
