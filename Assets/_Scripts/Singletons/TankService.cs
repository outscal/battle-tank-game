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
        TankModel tankModel = new TankModel(15f);
        TankController tankController = new TankController(tankModel, tankView);
        return tankController;
    }
}
