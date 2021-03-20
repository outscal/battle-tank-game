using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : GenericSingletonClass<EnemySpawner>
{
    // The GameObject to instantiate.
    public NormalEnemy enemyTankPrefab;

    // An instance of the ScriptableObject defined.
    public TankConfig Normal, Medium, Hard;


    private float randomX1, randomZ1, randomX2, randomZ2, randomX3, randomZ3;
    public List<GameObject> normalEnemyTankList = new List<GameObject>();
    public List<GameObject> mediumEnemyTankList = new List<GameObject>();
    public List<GameObject> hardEnemyTankList = new List<GameObject>();
    public Renderer rend;

    public List<GameObject> allEnemyTankList = new List<GameObject>();

    public int enemyCounter;

    private void Start()
    {
        Normal.numberOfTanksToCreate = GameManager.Instance.getNormalTanks;
        Medium.numberOfTanksToCreate = GameManager.Instance.getMediumTanks;
        Hard.numberOfTanksToCreate = GameManager.Instance.getHardTanks;

        SpawnEntities1(Normal);
        SpawnEntities2(Medium);
        SpawnEntities3(Hard);
        CountTotalTanks();
    }

    private void OnEnable()
    {
        rend = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>();

    }

    private void Update()
    {

        NextRound();
        Debug.Log(allEnemyTankList.Count);
    }

    void NextRound() {
        if (allEnemyTankList.Count <= 0) {
            SpawnEntities1(Normal);
            SpawnEntities2(Medium);
            SpawnEntities3(Hard);
            CountTotalTanks();
        }
    }
    void CountTotalTanks()
    {
        allEnemyTankList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    void SpawnEntities1(TankConfig Normal)
    {

        for (int i = 0; i < Normal.numberOfTanksToCreate; i++)
        {
            randomX1 = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            randomZ1 = Random.Range(rend.bounds.min.z, rend.bounds.max.z);
            //Creating random spawn point vector
            Vector3 spawnPoint1 = new Vector3(randomX1, 0, randomZ1);

            var normalTank = Instantiate(enemyTankPrefab, spawnPoint1, Quaternion.identity);
            normalTank.tankConfig = Normal;

            //normalTank.name = normal.name;
            normalEnemyTankList.Add(normalTank.gameObject);
            normalTank.gameObject.name = "NormalTank " + i;
            //Debug.Log("Added: " + normalEnemyTankList[i]);


            normalTank.gameObject.FindInChildren("TankChassis").GetComponent<Renderer>().material = Normal.color;
            normalTank.gameObject.FindInChildren("TankTracksLeft").GetComponent<Renderer>().material = Normal.color;
            normalTank.gameObject.FindInChildren("TankTracksRight").GetComponent<Renderer>().material = Normal.color;
            normalTank.gameObject.FindInChildren("TankTurret").GetComponent<Renderer>().material = Normal.color;

            enemyCounter++;
        }

    }

    void SpawnEntities2(TankConfig Medium)
    {


        for (int j = 0; j < Medium.numberOfTanksToCreate; j++)
        {
            randomX2 = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            randomZ2 = Random.Range(rend.bounds.min.z, rend.bounds.max.z);
            //Creating random spawn point vector
            Vector3 spawnPoint2 = new Vector3(randomX2, 0, randomZ2);

            var mediumTank = Instantiate(enemyTankPrefab, spawnPoint2, Quaternion.identity);
            mediumTank.tankConfig = Medium;

            //mediumTank.name = medium.name;
            mediumEnemyTankList.Add(mediumTank.gameObject);
            mediumTank.gameObject.name = "MediumTank " + j;
            //Debug.Log("Added: " + mediumEnemyTankList[j]);



            mediumTank.gameObject.FindInChildren("TankChassis").GetComponent<Renderer>().material = Medium.color;
            mediumTank.gameObject.FindInChildren("TankTracksLeft").GetComponent<Renderer>().material = Medium.color;
            mediumTank.gameObject.FindInChildren("TankTracksRight").GetComponent<Renderer>().material = Medium.color;
            mediumTank.gameObject.FindInChildren("TankTurret").GetComponent<Renderer>().material = Medium.color;

            enemyCounter++;
        }

    }

    void SpawnEntities3(TankConfig Hard)
    {

        for (int k = 0; k < Hard.numberOfTanksToCreate; k++)
        {
            randomX3 = Random.Range(rend.bounds.min.x, rend.bounds.max.x);
            randomZ3 = Random.Range(rend.bounds.min.z, rend.bounds.max.z);
            //Creating random spawn point vector
            Vector3 spawnPoint3 = new Vector3(randomX3, 0, randomZ3);

            var hardTank = Instantiate(enemyTankPrefab, spawnPoint3, Quaternion.identity);
            hardTank.tankConfig = Hard;

            //hardTank.name = Hard.name;
            hardEnemyTankList.Add(hardTank.gameObject);
            hardTank.gameObject.name = "HardTank " + k;
            //Debug.Log("Added: " + hardEnemyTankList[k]);


            hardTank.gameObject.FindInChildren("TankChassis").GetComponent<Renderer>().material = Hard.color;
            hardTank.gameObject.FindInChildren("TankTracksLeft").GetComponent<Renderer>().material = Hard.color;
            hardTank.gameObject.FindInChildren("TankTracksRight").GetComponent<Renderer>().material = Hard.color;
            hardTank.gameObject.FindInChildren("TankTurret").GetComponent<Renderer>().material = Hard.color;

            enemyCounter++;
        }

    }
}