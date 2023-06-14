public class PlayerTankSingleton : GenericSingleton<PlayerTankSingleton>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void MovePlayer()
    {
        // Sample function to make use of EnemyTank singleton
        EnemyTankSingleton.Instance.MoveEnemy();
    }
}
