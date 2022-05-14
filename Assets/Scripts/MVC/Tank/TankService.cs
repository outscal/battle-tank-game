using UnityEngine;
public class TankService : MonoGenericSingleton<TankService>
{
    public TankView m_tankView;
    public EnemyTankView m_enemyTankView;
    public TankListSO m_tankListSO;
    public EnemyTankListSO m_enemyTankListSO;

    private void Start()
    {
        CreateNewTank();
    }

    private void CreateNewTank()
    {
        #region creating player
        TankSO tankSO = m_tankListSO.tanks[Random.Range(0, m_tankListSO.tanks.Length)];

        //creating player tank model
        TankModel tankModel = new TankModel(tankSO);

        //spawning the tank using the created tank model
        TankController tankController = new TankController(tankModel, m_tankView);
        #endregion


        #region creating enemy tank models
        for (int i = 0; i < m_enemyTankListSO.enemyTanks.Length; i++)
        {
            EnemyTankSO enemyTankSO = m_enemyTankListSO.enemyTanks[i];
            EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankSO);
            EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, m_enemyTankView);
        }
        #endregion


    }
}