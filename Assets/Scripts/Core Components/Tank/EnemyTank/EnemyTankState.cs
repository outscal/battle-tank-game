public abstract class EnemyTankState
{
    public EnemyTankController EnemyTankController { get; }

    public EnemyTankState(EnemyTankController enemyTankController)
    {
        EnemyTankController = enemyTankController;
    }

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }

    public abstract void Tick();
}