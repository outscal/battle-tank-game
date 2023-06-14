public class EnemyTankSingleton : GenericSingleton<EnemyTankSingleton>
{
    public void MoveEnemy()
    {
        PlayerTankSingleton.Instance.MovePlayer();
    }
}
