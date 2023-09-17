using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("tank controller created the tank view.", TankView);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }
    
}
