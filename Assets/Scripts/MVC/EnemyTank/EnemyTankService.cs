using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoGenericSingleton<EnemyTankService>
{
    public EnemyTankView _enemyTankView;
    public EnemyTankSO[] _enemyTankScriptableObjects;

    private void Start()
    {
        CreateNewEnemyTank();
    }

    private void CreateNewEnemyTank()
    {
        //creating a enemyTank model
        EnemyTankSO enemyTankScriptableObject = _enemyTankScriptableObjects[Random.Range(0, _enemyTankScriptableObjects.Length)];
        EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankScriptableObject);

        //spawning the enemyTank using the created enemyTank model
        EnemyTankController enemyTankController = new EnemyTankController(enemyTankModel, _enemyTankView);
    }
}