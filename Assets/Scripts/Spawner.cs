using System.Collections.Generic;
using UnityEngine;

public class Spawner : GenericSingletonClass<Spawner>
{
    // The GameObject to instantiate.
    public GameObject enemyTank;

    // An instance of the ScriptableObject defined above.
    public EnemySpawnManagerScriptableObject enemySpawnManagerValues;

    private float randomX, randomZ;

    public List<GameObject> enemyTankList;

    public Renderer rend;



    private void Start()
    {
        rend = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>();
    }

private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            SpawnEntities();
        }

        //if (enemyTankList == null)
        //{
        //enemyTankList = GameObject.FindGameObjectsWithTag("Enemy");
        //}
    }

    void SpawnEntities()
    {
        randomX = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
        randomZ = Random.Range(rend.bounds.min.z, rend.bounds.max.z);

        //Creating random spawn point vector
        Vector3 spawnPoint = new Vector3(randomX, 0, randomZ);

        for (int i = 0; i < enemySpawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            // Creates an instance of the prefab
            enemyTankList.Add(Instantiate(enemyTank, spawnPoint, Quaternion.identity));
        }
    }
}