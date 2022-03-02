using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : Singleton_Generic<TankService>
{
    public TankView tankView;

    private void Start()
    {
        SpawnTank();
    }

    private TankController SpawnTank()
    {
        TankModel model = new TankModel(5, 100);
        TankController controller = new TankController(model, tankView);
        return controller;
    }
}
