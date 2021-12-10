using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : SingletonGeneric<TankService>
{
    public ScriptableObjectList tankList;
    public TankView tankView;

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
        int random = Random.Range(0, tankList.tank.Length - 1);
        TankScriptableObjects tankScriptableObjects = tankList.tank[random];
        TankModel tankModel = new TankModel(tankScriptableObjects);
        TankController tank = new TankController(tankModel, tankView);
        return tank;
    }
}