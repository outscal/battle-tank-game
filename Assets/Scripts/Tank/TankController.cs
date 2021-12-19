using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController 
{
   public TankController(TankModel tankmodel,TankView tankPrefab)
    //public TankController(TankModel tankModel,GameObject tanlPrefab)
    {
        TankModel = tankmodel;

        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("tank view created", TankView);
    }
    public TankModel TankModel { get; }
    public TankView TankView { get; }
}
