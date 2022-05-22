using UnityEngine;

public abstract class ETankBaseState
{
    //public EnemyTankView EnemyTankView { get; }
    //public EnemyTankModel EnemyTankModel { get; }

    public abstract void EnterState(ETankStateManager enemyTankStateManager);
    public abstract void UpdateState(ETankStateManager enemyTankStateManager);
    //public abstract void ExitState(EnemyTankStateManager enemyTankStateManager);
    //public abstract void OnCollisionEnter(EnemyTankStateManager enemyTankStateManager);
}