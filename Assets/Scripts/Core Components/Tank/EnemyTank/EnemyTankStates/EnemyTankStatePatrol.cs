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

        float horizontal = EnemyTankController.Horizontal, vertical = EnemyTankController.Vertical;

        // movement senstivity threshold
        if (horizontal >= .2f || horizontal <= -.2f || vertical >= .2f || vertical <= -.2f)
        {
            Vector3 position = EnemyTankView.Position;
            position.x += horizontal * EnemyTankModel.Speed * Time.deltaTime;
            position.z += vertical * EnemyTankModel.Speed * Time.deltaTime;

            Vector3 rotation = new Vector3(horizontal, position.y, vertical);

            EnemyTankView.Rotation = Quaternion.LookRotation(rotation);
            EnemyTankView.Position = position;
            EnemyTankView.ApplyTranform = true;
        }

        // if there is no time left then move back idle state
        if (timeLeft <= 0)
            EnemyTankController.SetState(EnemyTankStates.Idle);
    }
}