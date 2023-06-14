public class EnemyTankSingleton : GenericSingleton<EnemyTankSingleton>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void MoveEnemy()
    {
        // Sample function to make use of PlayerTank singleton
        PlayerTankSingleton.Instance.MovePlayer();
    }
}
