using UnityEngine;

class EnemyTankStatePatrol : EnemyTankState
{

    float timeLeft;

    public EnemyTankStatePatrol(EnemyTankController enemyTankController) : base(enemyTankController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyTankModel.CurrentState = EnemyTankStates.Patrol;

        // Setting random time in seconds
        timeLeft = UnityEngine.Random.Range(3f, 15f);

        EnemyTankController.ResetDirection();
    }

    public override void OnStateExit() { }

    public override void Tick()
    {
        timeLeft -= Time.deltaTime;

        // if there is no time left then move back idle state
        if (timeLeft <= 0)
            EnemyTankController.SetState(EnemyTankStates.Idle);
    }
}