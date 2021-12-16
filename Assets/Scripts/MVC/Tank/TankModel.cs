using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using UnityEngine;

public class TankModel 
{
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;

    }

    public TankModel(TankType tankType,float speed, float health)
    {
        TankType = tankType;
        Speed = speed;
        Health = health;
        Debug.Log("Scriptable Object created");
    }

    public TankType TankType { get; }
    public float Speed { get; private set; }
    public float Health { get; private set; }
}
