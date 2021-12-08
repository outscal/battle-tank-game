using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : SingletonGeneric<TankService>
{
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
        TankModel tankModel = new TankModel(5, 100f);
        TankController tank = new TankController(tankModel, tankView);
        return tank;
    }
}