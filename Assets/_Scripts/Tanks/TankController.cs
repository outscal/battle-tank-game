using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
    //public TankController (TankModel tankModel, TankView tankPrefab)
    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        
        //GameObject go = GameObject.Instantiate(tankPrefab);
        //TankView = go.GetComponent<TankView>();
        Debug.Log("Tank View Created",TankView);

    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }
}
