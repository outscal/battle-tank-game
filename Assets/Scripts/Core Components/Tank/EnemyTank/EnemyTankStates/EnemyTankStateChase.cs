using UnityEngine;

class EnemyTankStateChase : EnemyTankState
{
    public EnemyTankStateChase(EnemyTankController enemyTankController) : base(enemyTankController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyTankModel.CurrentState = EnemyTankStates.Chase;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        EnemyTankController.CanSeePlayer();
    }
}