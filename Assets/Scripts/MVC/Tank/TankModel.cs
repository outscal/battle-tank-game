using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using UnityEngine;

public class TankModel 
{
    public TankType TankType { get; }
    public float Speed { get; private set; }
    public float Health { get; set; }

    public float minLaunchForce { get; set; }
    public float  maxLaunchForce { get; set; }
    public float maxChargeTime { get; set; }

    public bool b_Is_Dead { get; set; }
    public bool b_IsFired { get; set; }
    private TankScriptableObject tankScriptableObject;
    private int playerID;


    public TankModel(TankScriptableObject tankScriptableObject)
    {
        b_Is_Dead = false;
        b_IsFired = false;
        TankType = tankScriptableObject.TankType;
        Speed = tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        minLaunchForce = tankScriptableObject.minLaunchForce;
        maxLaunchForce = tankScriptableObject.maxLaunchForce;
        maxChargeTime = tankScriptableObject.maxChargeTime;

        playerID = Random.Range(1, 100000);
    }

    public TankModel(TankType tankType,float speed, float health)
    {
        TankType = tankType;
        Speed = speed;
        Health = health;
        Debug.Log("Scriptable Object created");
    }

    
}
