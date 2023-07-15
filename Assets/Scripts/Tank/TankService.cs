using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public PlayerTankView playerTankView;
    public EnemyTankView enemyTankView;
    public TankScriptableObjectList tankScriptableObjectList;
    [SerializeField]
    private BulletView bulletPrefab;

    void Start()
    {
        //SpawnPlayerTank();
        //SpawnEnemyTank();
    }

    private void SpawnEnemyTank()
    {
        EnemyTankModel model = new(tankScriptableObjectList.tankScriptableObjects[0]);
        EnemyTankController controller = new(model, enemyTankView);
    }

    private void SpawnPlayerTank()
    {
        PlayerTankModel model = new(tankScriptableObjectList.tankScriptableObjects[0]);
        PlayerTankController controller = new(model, playerTankView);
    }

}
