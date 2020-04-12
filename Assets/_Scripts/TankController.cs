using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }

    public TankController(TankModel tankModel, TankView tankView)
    {
        Debug.Log("tank controller created");
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankView);

        //this.tankView.tankController = this;
        TankView.SetTankController(this);
    }

    public Vector3 MoveTank(float horizontal, float vertical, Vector3 position)
    {
        Debug.Log("Function called");
        position.x += horizontal * TankModel.Speed * Time.deltaTime;
        position.z += vertical * TankModel.Speed * Time.deltaTime;
        return position;
    }
}
