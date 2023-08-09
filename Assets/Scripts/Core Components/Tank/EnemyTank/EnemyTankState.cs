public abstract class EnemyTankState
{
    public EnemyTankController EnemyTankController { get; }
    public EnemyTankModel EnemyTankModel { get; }

    public EnemyTankState(EnemyTankController enemyTankController)
    {
        EnemyTankController = enemyTankController;
        EnemyTankModel = enemyTankController.EnemyTankModel;
    }

    public virtual void OnStateEnter()
    { }

    public virtual void OnStateExit() { }

    public abstract void Tick();
}