using System;
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

        //this.tankView.tankController = this;
        this.tankView.SetTankController(this);
        //GameObject go = GameObject.Instantiate(tankView);
    }

    public Vector3 moveTank(float horizontal, float vertical, Vector3 position)
    {
        Debug.Log("Function called");
        position.x += horizontal * tankModel.Speed * Time.deltaTime;
        position.z += vertical * tankModel.Speed * Time.deltaTime;
        return position;
    }
}
