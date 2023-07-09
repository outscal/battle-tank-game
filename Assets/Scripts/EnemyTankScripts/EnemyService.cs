using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : GenericSingleton<EnemyService>
{
    private int maxEnemyCount = 10;
    private Transform playerTransform;
    private List<EnemyController> enemies;
    private List<Transform> spawnPoints;
    private List<Transform> pointsAlreadySpawned;

    [SerializeField] private EnemyScriptableObjectList enemyTankList;
    [SerializeField] private ParticleSystem tankExplosion;
    [SerializeField] private Transform SpawnPointParent;
    [SerializeField] private int enemyCount = 3;

    void Start()
    {
        enemies = new List<EnemyController>();
        spawnPoints = new List<Transform>();
        pointsAlreadySpawned = new List<Transform>();
        playerTransform = TankService.Instance.GetPlayerTransform();

        enemyCount = Mathf.Min(enemyCount, maxEnemyCount);

        foreach (Transform item in SpawnPointParent)
            spawnPoints.Add(item);

        StartCoroutine(SpawnEnemyTanks(enemyCount));
    }

    IEnumerator SpawnEnemyTanks(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 newPosition = GetRandomSpawnPoint();
            int enemyType = GetRandomEnemyType();

            if (newPosition == Vector3.zero)
                break;

            EnemyController enemyController = CreateEnemyTank(enemyType, newPosition);
            enemies.Add(enemyController);

            yield return new WaitForSeconds(0.1f);
        }
    }

    public Vector3 GetRandomSpawnPoint()
    {
        if (spawnPoints.Count == 0)
            return Vector3.zero;

        int spawnPointIndex = Random.Range(0, spawnPoints.Count);
        Transform newTransform = spawnPoints[spawnPointIndex];

        pointsAlreadySpawned.Add(spawnPoints[spawnPointIndex]);
        spawnPoints.RemoveAt(spawnPointIndex);

        return newTransform.position;
    }

    public int GetRandomEnemyType()
    {
        return Random.Range(0, enemyTankList.enemies.Length);
    }

    public EnemyController CreateEnemyTank(int enemyTypeIndex, Vector3 newPosition)
    {
        EnemyScriptableObject enemy = enemyTankList.enemies[enemyTypeIndex];
        EnemyController enemyController = new EnemyController(enemy, newPosition, playerTransform);

        return enemyController;
    }

    public void ShootBullet(BulletType bulletType, Transform gunTransform)
    {
        BulletService.Instance.SpawnBullet(bulletType, gunTransform);
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
        List<EnemyController> enemyList = new List<EnemyController>(enemies);

        yield return new WaitForSeconds(2f);

        foreach (EnemyController enemy in enemyList)
        {
            DestoryEnemy(enemy);
            yield return new WaitForSeconds(1f);
        }
    }
}
