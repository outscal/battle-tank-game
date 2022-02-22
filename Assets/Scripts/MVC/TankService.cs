using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : Singleton_Generic<TankService>
{
    public TankView tankView;

    public TankScriptableObj[] tankConfigs;

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreateNewTank();
    }


    private TankController CreateNewTank()
    {
        TankScriptableObj tankScriptableObj = tankConfigs[Random.Range(0, tankConfigs.Length)];
        TankModel tankModel = new TankModel(tankScriptableObj);
        TankController tank = new TankController(tankModel, tankView);
        return tank;
    }
}