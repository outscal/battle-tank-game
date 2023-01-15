using System.Collections;
using UnityEngine;

public class EnemyService : MonoSingletonGeneric<EnemyService>
{
    public EnemyTankScriptableObjectList enemyList;
    public Vector3[] spawnAreas;
    public float spawnInterval = 5f;

    private int spawnIndex;
    private WaitForSeconds spawnWait;

    private void Start()
    {
        spawnWait = new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            CreateNewEnemy();
            yield return spawnWait;
        }
    }


    private void CreateNewEnemy()
    {
        int randomIndex = Random.Range(0, enemyList.eTanks.Length);
        EnemyTankScriptableObject enemyTankScriptableObject = enemyList.eTanks[randomIndex];
        GameObject enemyObject = Instantiate(enemyTankScriptableObject.prefab);
        enemyObject.transform.position = spawnAreas[spawnIndex];

        spawnIndex++;
        if (spawnIndex >= spawnAreas.Length)
        {
            spawnIndex = 0;
        }
    }
}