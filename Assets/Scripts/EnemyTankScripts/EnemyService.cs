using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyService : GenericSingleton<EnemyService>
{
    [SerializeField] EnemyScriptableObjectList enemyTankList;
    [SerializeField] int enemyCount = 3;
    [SerializeField] ParticleSystem tankExplosion;
    List<EnemyController> enemies;
    [SerializeField] Transform SpawnPointParent;
    Transform playerTransform;
    List<Transform> spawnPoints;
    List<Transform> pointsAlreadySpawned;
    void Start()
    {
        spawnPoints = new List<Transform>();
        pointsAlreadySpawned = new List<Transform>();
        foreach (Transform item in SpawnPointParent)
        {
            spawnPoints.Add(item);
        }
        enemies = new List<EnemyController>();
        playerTransform = TankService.Instance.GetPlayerTransform();
        StartCoroutine(SpawnEnemyTanks(enemyCount));
    }
    IEnumerator SpawnEnemyTanks(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Transform newTransform = GetRandomSpawnPoint();
            if (newTransform == null)
                break;
            EnemyController enemyController = CreateEnemyTank(Random.Range(0, enemyTankList.enemies.Length), newTransform);
            enemies.Add(enemyController);
            yield return new WaitForSeconds(0.1f);
        }
    }
    public EnemyController CreateEnemyTank(int index, Transform newTransform)
    {
        EnemyScriptableObject enemy = enemyTankList.enemies[index];
        EnemyController enemyController = new EnemyController(enemy, newTransform.position, playerTransform);
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
            yield return new WaitForSeconds(1f);
        }
    }
    public Transform GetRandomSpawnPoint()
    {
        if (spawnPoints.Count == 0)
            return null;
        int index = 0;
        index = Random.Range(0, spawnPoints.Count);
        Transform newTransform = spawnPoints[index];
        pointsAlreadySpawned.Add(spawnPoints[index]);
        spawnPoints.RemoveAt(index);
        return newTransform;
    }
}
