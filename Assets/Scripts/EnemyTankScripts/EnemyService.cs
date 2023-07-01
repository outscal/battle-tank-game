using UnityEngine;
public class EnemyService : GenericSingleton<EnemyService>
{
    [SerializeField] TankScriptableObjectList enemyTankList;
    [SerializeField] int enemyCount = 3;
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            CreateEnemyTank(Random.Range(0, enemyTankList.tanks.Length));
        }
    }
    public void CreateEnemyTank(int index)
    {
        TankScriptableObject tank = enemyTankList.tanks[index];
        EnemyController enemyController = new EnemyController(tank, 10, 4);
    }
    public void ShootBullet(BulletType bulletType, Transform tankTransform)
    {
        BulletService.Instance.SpawnBullet(bulletType, tankTransform);
    }
    public void DestoryTank(TankView tankView)
    {
        Destroy(tankView.gameObject);
    }
}
