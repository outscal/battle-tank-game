using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; }
    public TankView tankView { get; }

    public TankController(TankModel tankModel, TankView tankView)
    {
        Debug.Log("tank controller created");
        this.tankModel = tankModel;
        this.tankView = GameObject.Instantiate<TankView>(tankView);
        //GameObject go = GameObject.Instantiate(tankView);
    }
}
