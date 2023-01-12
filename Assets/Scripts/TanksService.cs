using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;

    private void Start()
    {
        CreateNewTank();
    }

    private TankController CreateNewTank()
    {
        TankModel model = new TankModel(10, 50f, TankType.MediumTank, BulletType.Standard);
        TankController tank = new TankController(model, tankView);
        return tank;
    }
    
}