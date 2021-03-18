using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : GenericSingletonClass<EnemySpawner>
{
    // The GameObject to instantiate.
    public GameObject enemyTankPrefab;

    // An instance of the ScriptableObject defined above.
    public NormalEnemySpawnManagerScriptableObject normalSpawnManagerValues;
    public MediumEnemySpawnManagerScriptableObject mediumSpawnManagerValues;
    public HardEnemySpawnManagerScriptableObject hardSpawnManagerValues;

    private float randomX1, randomZ1, randomX2, randomZ2, randomX3, randomZ3;
    public List<GameObject> normalEnemyTankList = new List<GameObject>();
    public List<GameObject> mediumEnemyTankList = new List<GameObject>();
    public List<GameObject> hardEnemyTankList = new List<GameObject>();
    public Renderer rend;

    public List<GameObject> allEnemyTankList = new List<GameObject>();
    public int enemyCounter;


    private void Start()
    {
        rend = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>();
        PoolManager.SetNetPoolSize(enemyTankPrefab, 20);
        PoolManager.SetPoolSize(enemyTankPrefab, 10);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.touchCount == 1)
        {
            SpawnEntities1();
            SpawnEntities2();
            SpawnEntities3();
            CountTotalTanks();
        }
    }
    void CountTotalTanks()
    {
        allEnemyTankList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        enemyCounter = allEnemyTankList.Count;
    }

    void SpawnEntities1()
    {

        for (int i = 0; i < normalSpawnManagerValues.numberOfNormalEnemyTanksToCreate; i++)
        {
            randomX1 = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            randomZ1 = Random.Range(rend.bounds.min.z, rend.bounds.max.z);
            //Creating random spawn point vector
            Vector3 spawnPoint1 = new Vector3(randomX1, 0, randomZ1);

            GameObject normalTank = Instantiate(enemyTankPrefab, spawnPoint1, Quaternion.identity);
            normalTank.AddComponent<NormalEnemy>();


            normalTank.name = normalSpawnManagerValues.enemyTankPrefab;
            normalEnemyTankList.Add(normalTank);
            //Debug.Log("Added: " + normalEnemyTankList[i]);


            normalTank.FindInChildren("TankChassis").GetComponent<Renderer>().material = normalSpawnManagerValues.red;
            normalTank.FindInChildren("TankTracksLeft").GetComponent<Renderer>().material = normalSpawnManagerValues.red;
            normalTank.FindInChildren("TankTracksRight").GetComponent<Renderer>().material = normalSpawnManagerValues.red;
            normalTank.FindInChildren("TankTurret").GetComponent<Renderer>().material = normalSpawnManagerValues.red;

        }

    }

    void SpawnEntities2()
    {


        for (int j = 0; j < mediumSpawnManagerValues.numberOfMediumEnemyTanksToCreate; j++)
        {
            randomX2 = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            randomZ2 = Random.Range(rend.bounds.min.z, rend.bounds.max.z);
            //Creating random spawn point vector
            Vector3 spawnPoint2 = new Vector3(randomX2, 0, randomZ2);

            GameObject mediumTank = Instantiate(enemyTankPrefab, spawnPoint2, Quaternion.identity);
            mediumTank.AddComponent<MediumEnemy>();
            mediumTank.name = mediumSpawnManagerValues.enemyTankPrefab;
            mediumEnemyTankList.Add(mediumTank);
            //Debug.Log("Added: " + mediumEnemyTankList[j]);


            mediumTank.FindInChildren("TankChassis").GetComponent<Renderer>().material = mediumSpawnManagerValues.blue;
            mediumTank.FindInChildren("TankTracksLeft").GetComponent<Renderer>().material = mediumSpawnManagerValues.blue;
            mediumTank.FindInChildren("TankTracksRight").GetComponent<Renderer>().material = mediumSpawnManagerValues.blue;
            mediumTank.FindInChildren("TankTurret").GetComponent<Renderer>().material = mediumSpawnManagerValues.blue;
           

        }

    }

    void SpawnEntities3()
    {

        for (int k = 0; k < hardSpawnManagerValues.numberOfHardEnemyTanksToCreate; k++)
        {
            randomX3 = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            randomZ3 = Random.Range(rend.bounds.min.z, rend.bounds.max.z);
            //Creating random spawn point vector
            Vector3 spawnPoint3 = new Vector3(randomX3, 0, randomZ3);

            GameObject hardTank = Instantiate(enemyTankPrefab, spawnPoint3, Quaternion.identity);
            hardTank.AddComponent<HardEnemy>();
            hardTank.name = hardSpawnManagerValues.enemyTankPrefab;
            hardEnemyTankList.Add(hardTank);
            //Debug.Log("Added: " + hardEnemyTankList[k]);


            hardTank.FindInChildren("TankChassis").GetComponent<Renderer>().material = hardSpawnManagerValues.yellow;
            hardTank.FindInChildren("TankTracksLeft").GetComponent<Renderer>().material = hardSpawnManagerValues.yellow;
            hardTank.FindInChildren("TankTracksRight").GetComponent<Renderer>().material = hardSpawnManagerValues.yellow;
            hardTank.FindInChildren("TankTurret").GetComponent<Renderer>().material = hardSpawnManagerValues.yellow;

        }

    }
}