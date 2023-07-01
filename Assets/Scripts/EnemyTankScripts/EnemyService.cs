using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyService : GenericSingleton<EnemyService>
{
    [SerializeField] EnemyScriptableObjectList enemyTankList;
    [SerializeField] int enemyCount = 3;
    [SerializeField] ParticleSystem tankExplosion;
    List<EnemyController> enemies;
    void Start()
    {
        enemies = new List<EnemyController>();
        for (int i = 0; i < enemyCount; i++)
        {
            EnemyController enemyController = CreateEnemyTank(Random.Range(0, enemyTankList.enemies.Length));
            enemies.Add(enemyController);
        }
    }
    public EnemyController CreateEnemyTank(int index)
    {
        EnemyScriptableObject enemy = enemyTankList.enemies[index];
        EnemyController enemyController = new EnemyController(enemy, 10, 4);
        return enemyController;
    }
    public void ShootBullet(BulletType bulletType, Transform tankTransform)
    {
        BulletService.Instance.SpawnBullet(bulletType, tankTransform);
    }
    public void DestoryEnemy(EnemyController _enemyController)
    {
        Vector3 pos = _enemyController.GetPosition();
        Destroy(_enemyController.enemyView.gameObject);
        enemies.Remove(_enemyController);
        StartCoroutine(TankExplosion(pos));
    }
    public IEnumerator TankExplosion(Vector3 tankPos)
    {
        ParticleSystem newTankExplosion = GameObject.Instantiate<ParticleSystem>(tankExplosion, tankPos, Quaternion.identity);
        newTankExplosion.Play();
        yield return new WaitForSeconds(2f);
        Destroy(newTankExplosion.gameObject);
    }
    public IEnumerator DestroyAllEnemies()
    {
        yield return new WaitForSeconds(2f);
        List<EnemyController> enemyList = new List<EnemyController>(enemies);
        foreach (EnemyController enemy in enemyList)
        {
            DestoryEnemy(enemy);
            yield return new WaitForSeconds(2f);
        }
    }
}
