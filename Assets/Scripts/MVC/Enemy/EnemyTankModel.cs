public class EnemyTankModel
{
    private EnemyTankController m_enemyTankController;

    //-----model data/variables-----
    public TankType TankType { get; }
    public string TankName { get; }
    public float Speed { get; }
    public float Health { get; }


    //-----constructor-----
    public EnemyTankModel(EnemyTankSO enemyTankSO)
    {
        TankType = enemyTankSO.Tanktype;
        TankName = enemyTankSO.TankName;
        Health = enemyTankSO.Health;
        Speed = enemyTankSO.Speed;
    }


    //-----controller reference-----
    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        m_enemyTankController = enemyTankController;
    }
}
