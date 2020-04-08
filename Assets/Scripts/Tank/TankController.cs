using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankController(TankModel tankModel, TankView tankPrefab, Transform spawner)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankPrefab, spawner.transform.position, spawner.transform.rotation);
        TankView.SetViewDetails(tankModel);
    }


    public TankModel TankModel { get; }
    public TankView TankView { get; }
}
