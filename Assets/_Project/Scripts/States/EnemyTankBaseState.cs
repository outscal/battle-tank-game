using UnityEngine;

public abstract class EnemyTankBaseState
{
    //public EnemyTankView EnemyTankView { get; }
    //public EnemyTankModel EnemyTankModel { get; }

    public abstract void EnterState(EnemyTankStateManager enemyTankStateManager);
    public abstract void UpdateState(EnemyTankStateManager enemyTankStateManager);
    //public abstract void ExitState(EnemyTankStateManager enemyTankStateManager);
    //public abstract void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager);
}
