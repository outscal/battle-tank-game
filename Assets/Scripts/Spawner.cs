using UnityEngine;

public class Spawner : GenericSingletonClass<Spawner>
{
    // The GameObject to instantiate.
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public EnemySpawnManagerScriptableObject enemySpawnManagerValues;

    private float randomX, randomZ;

    public Renderer rend;

    public GameObject go;

    private void Start()
    {
        rend = go.GetComponent<Renderer>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.Alpha0))
        {
            SpawnEntities();
        }
    }

    void SpawnEntities()
    {
        randomX = Random.Range(rend.bounds.min.x, rend.bounds.max.x);

        randomZ = Random.Range(rend.bounds.min.z, rend.bounds.max.z);

        //Creating random spawn point
        enemySpawnManagerValues.spawnPoint = new Vector3(randomX, 0, randomZ);

        for (int i = 0; i < enemySpawnManagerValues.numberOfPrefabsToCreate; i++)
        {
            // Creates an instance of the prefab at the current spawn point.
            GameObject currentEntity = Instantiate(entityToSpawn, enemySpawnManagerValues.spawnPoint, Quaternion.identity);
        }
    }
}   