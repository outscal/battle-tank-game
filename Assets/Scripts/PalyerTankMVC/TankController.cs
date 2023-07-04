using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private float tankSpeed;
    private Rigidbody rb;
   

    public TankController(TankModel _tankModel, TankView _tankView)
    {
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        tankSpeed = tankModel.Speed;
        rb = tankView.GetRigidbody();

        tankView.SetTankController(this);
        tankModel.SetTankController(this);
    }
    public TankModel GetModel()
    {
        return tankModel;
    }
}
