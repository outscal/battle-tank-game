using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }
    public TankController(TankModel tankModel, TankView tankView, Vector3 spawnLoc)
    {
        TankModel = tankModel;
        TankView = tankView;
        GameObject tankGO = Instantiate(tankView.gameObject, spawnLoc, Quaternion.identity); 
    }

  
}
