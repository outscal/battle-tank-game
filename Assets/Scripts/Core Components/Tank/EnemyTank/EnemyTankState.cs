public abstract class EnemyTankState
{
    public EnemyTankController EnemyTankController { get; }
    public EnemyTankModel EnemyTankModel { get; }
    public EnemyTankView EnemyTankView { get; }

    public EnemyTankState(EnemyTankController enemyTankController)
    {
        EnemyTankController = enemyTankController;
        EnemyTankModel = enemyTankController.EnemyTankModel;
        EnemyTankView = enemyTankController.EnemyTankView;
    }

    public virtual void OnStateEnter()
    { }

    public virtual void OnStateExit() { }

    public abstract void Tick();
}