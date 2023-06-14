public class PlayerTankSingleton : GenericSingleton<PlayerTankSingleton>
{
    public void MovePlayer()
    {
        EnemyTankSingleton.Instance.MoveEnemy();
    }
}
