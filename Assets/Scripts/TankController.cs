using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankController(TankModel tankModel, TankView tankView)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankView);
        Debug.Log("Tank view created");
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }
}
