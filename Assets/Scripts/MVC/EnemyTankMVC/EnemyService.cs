using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyService : MonoBehaviour
{
    [SerializeField] EnemyView enemyView;
    [SerializeField] TankTypeScriptableObjectList tankList;
    private EnemyController enemyConroller;

    private void Start()
    {
        SpawnEnemyTank();
    }

    private void SpawnEnemyTank()
    {
        enemyConroller = new EnemyController(new EnemyModel(EnemyTankRandom()), enemyView, this.gameObject.transform);
    }

    private TankTypeScriptableObject EnemyTankRandom()
    {
        TankTypeScriptableObject tankSO;
        int index = UnityEngine.Random.Range(0, tankList.list.Count);
        tankSO = tankList.list[index];
        return tankSO;
    }
}
