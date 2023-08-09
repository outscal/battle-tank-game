using UnityEngine;

class EnemyTankStateIdle : EnemyTankState
{

    float timeLeft;

    public EnemyTankStateIdle(EnemyTankController enemyTankController) : base(enemyTankController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyTankModel.CurrentState = EnemyTankStates.Idle;

        // Setting random time in seconds
        timeLeft = UnityEngine.Random.Range(1f, 5f);
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        timeLeft -= Time.deltaTime;

        // Change the state when time completes
        if (timeLeft <= 0)
            EnemyTankController.SetState(EnemyTankStates.Patrol);

    }
}