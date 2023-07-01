using UnityEngine;
public class EnemyService : GenericSingleton<EnemyService>
{
    [SerializeField] EnemyScriptableObjectList enemyTankList;
    [SerializeField] int enemyCount = 3;
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            CreateEnemyTank(Random.Range(0, enemyTankList.enemies.Length));
        }
    }
    public void CreateEnemyTank(int index)
    {
        EnemyScriptableObject enemy = enemyTankList.enemies[index];
        EnemyController enemyController = new EnemyController(enemy, 10, 4);
    }
    public void ShootBullet(BulletType bulletType, Transform tankTransform)
    {
        BulletService.Instance.SpawnBullet(bulletType, tankTransform);
    }
    public void DestoryEnemy(EnemyView enemyView)
    {
        Destroy(enemyView.gameObject);
    }
}
