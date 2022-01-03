using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{
    EnemyController tank;
    public EnemyTankView enemyTankview;
    public EnemyTankStats[] stats;
    public Transform[] spawnPoints;
    public Text tanksNo;
    public int maxEnemyTanks = 10;
    public int noOfTanks = 0;

    private GameObject[] enemyTanks;
    public bool activatePortal = false;
    public bool wavesCompleted = false;
    public void Start()
    {
        for(int i = 0; i < maxEnemyTanks; i++)
        {
            CreateTank();
        }
    }
    private void Update()
    {
        enemyTanks = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyTanks.Length == 0)
        {
            activatePortal = true;
        }
        tanksNo.text = "TANKS LEFT : " + enemyTanks.Length;
    }
    
    private EnemyController CreateTank()                  //Creating the tank with the required stats
    {
        EnemyTankStats Stats = stats[Random.Range(0,2)];
        EnemyTankModel model = new EnemyTankModel(Stats);
        tank = new EnemyController(model, enemyTankview);
        return tank;
    }
    public EnemyController GetEnemyController()
    {
        return tank;
    }
}
