using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerScript
{

    public TankControllerScript(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        //GameObject go = GameObject.Instantiate(tankPrefab);

        TankView = GameObject.Instantiate<TankView>(tankPrefab);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }
}
