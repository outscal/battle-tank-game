using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankController(TankModel tankModel, TankView tankView)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankView);    
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }
    
}
