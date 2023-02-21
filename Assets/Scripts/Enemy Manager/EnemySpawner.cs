using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    public Transform[] EnemyPatrol;
    public EnemyTankList tankObjectList;
    private Transform spawn;
    private EnemyPool pool;
    public int maxEnemies;
    private void OnEnable() {
        spawn = this.transform;
    }
    void Start()
    {
        
    }
    private void TankSpawn(int i)
    {
        EnemyModel enemyModel = new EnemyModel(tankObjectList.EnemyTanks[i]);
        pool.GetTank(enemyModel, tankObjectList.EnemyTanks[i].enemyView, EnemyPatrol);
        //EnemyController tankController = new EnemyController(enemyModel, tankObjectList.EnemyTanks[i].enemyView, spawn, EnemyPatrol);
    }
    private void EnemyWaves(int currentWave)
    {
        int enemyCount = 1;
        switch(currentWave)
        {
            case 1:
                    enemyCount = 1;
                    break;
            case 2:
                    enemyCount = 1;
                    break;
            case 3:
                    enemyCount = 1;
                    break;
            case 4:
                    enemyCount = 1;
                    break;
            case 5:
                    enemyCount = 1;
                    break;
            case 6:
                    enemyCount = 1;
                    break;
            default:
                    break;
        }
        for(int i = 1; i<=enemyCount; i++)
        {
            TankSpawn(i); 
        }
    }
}
