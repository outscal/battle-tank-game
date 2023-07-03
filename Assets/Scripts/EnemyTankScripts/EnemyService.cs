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
    [SerializeField] Transform PatrolPointParent;
    List<Transform> spawnPoints;
    List<Transform> pointsAlreadySpawned;
    List<Transform> patrolPoints;
    void Start()
    {
        spawnPoints = new List<Transform>();
        pointsAlreadySpawned = new List<Transform>();
        patrolPoints = new List<Transform>();
        foreach (Transform item in SpawnPointParent)
        {
            spawnPoints.Add(item);
        }
        foreach (Transform item in PatrolPointParent)
        {
            patrolPoints.Add(item);
        }
        enemies = new List<EnemyController>();
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
        EnemyController enemyController = new EnemyController(enemy, newTransform.position);
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
    public int GetRandomPatrolPoint(Vector3 _spawnPoint)
    {
        for (int i = 0; i < patrolPoints.Count; i++)
        {
            if (Vector3.Distance(patrolPoints[i].position, _spawnPoint) < 10f)
            {
                return i;
            }
        }
        Debug.Log("Near patrol point not found!");
        return -1;
    }
    public int GetRandomPatrolPoint(int _targetIndex)
    {
        if (_targetIndex >= patrolPoints.Count - 1)
            _targetIndex = 0;
        else
            _targetIndex++;
        return _targetIndex;
    }
    public Vector3 GetPatrolPosition(int index)
    {
        return patrolPoints[index].position;
    }
}
