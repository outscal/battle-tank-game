using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks.Tank
{
public class TankControllerScript
{

    public TankControllerScript(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;
        //GameObject go = GameObject.Instantiate(tankPrefab);

        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("tank view created", TankView);
    }

    public TankModel TankModel { get; }
    public TankView TankView { get; }
}
}