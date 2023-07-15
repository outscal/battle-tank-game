using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public PlayerTankView playerTankView;
    public TankScriptableObjectList tankScriptableObjectList;
    [SerializeField]
    private BulletView bulletPrefab;

    void Start()
    {
        SpawnPlayerTank();
    }

   

    private void SpawnPlayerTank()
    {
        PlayerTankModel model = new(tankScriptableObjectList.tankScriptableObjects[0]);
        PlayerTankController controller = new(model, playerTankView,transform.position);
    }

}
