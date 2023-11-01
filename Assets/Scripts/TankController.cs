using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    public TankController (TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = _tankView;
        GameObject.Instantiate(tankView.gameObject);

        tankModel.SetTankController(this);
        tankView.SetTankController(this);
    }
}

