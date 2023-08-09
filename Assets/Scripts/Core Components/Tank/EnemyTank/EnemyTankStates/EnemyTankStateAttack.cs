using UnityEngine;

class EnemyTankStateAttack : EnemyTankState
{

    public EnemyTankStateAttack(EnemyTankController enemyTankController) : base(enemyTankController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyTankModel.CurrentState = EnemyTankStates.Attack;
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        EnemyTankModel.TimeLeftForNextShot -= Time.deltaTime;

        if (EnemyTankModel.TimeLeftForNextShot <= 0)
        {
            EnemyTankModel.TimeLeftForNextShot = EnemyTankModel.FireRate;
            EnemyTankController.Shoot();
        }
    }
}