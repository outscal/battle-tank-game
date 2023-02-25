using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    public EnemyTankList tankObjectList;
    private Transform spawn;
    private void OnEnable() {
        spawn = this.transform;
    }
    void Start()
    {
            TankSpawn(0);
    }
    private void TankSpawn(int i)
    {
        EnemyModel enemyModel = new EnemyModel(tankObjectList.EnemyTanks[i]);
        EnemyController tankController = new EnemyController(enemyModel, tankObjectList.EnemyTanks[i].enemyView, spawn);
    }
}
