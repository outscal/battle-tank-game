using UnityEngine;

public abstract class EnemyTankBaseState
{
    public abstract void EnterState(EnemyTankStateManager enemyTankStateManager);
    public abstract void UpdateState(EnemyTankStateManager enemyTankStateManager);
    public abstract void onCollisionEnter(EnemyTankStateManager enemyTankStateManager);
}
