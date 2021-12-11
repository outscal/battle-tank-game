using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private Rigidbody rb;
    public TankModel TankModel { get; private set; }
    public TankView tankView { get; private set; }

    public TankController(TankModel tankModel, TankView tankView)
    {
        TankModel = tankModel;
        tankView = GameObject.Instantiate<TankView>(tankView);
        rb = tankView.GetComponent<Rigidbody>();
        tankView.SetTankController(this);
        TankModel.SetTankController(this);
    }
}
