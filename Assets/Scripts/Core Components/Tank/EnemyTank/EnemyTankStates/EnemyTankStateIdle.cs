using UnityEngine;

class EnemyTankStateIdle : EnemyTankState
{
    public EnemyTankStateIdle(EnemyTankController enemyTankController) : base(enemyTankController) { }

    public override void Tick()
    {
        EnemyTankController.SetState(EnemyTankStates.Patrol);
    }
}