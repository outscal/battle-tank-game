using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
   

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("Tank View created");
        PlayerMovement p = new PlayerMovement();
        p.nextPsoition();
    }

    void Update()
    {
        Debug.Log("Controller Update is called");
    }
    public TankModel TankModel { get; }
    public TankView TankView { get; } 
}
