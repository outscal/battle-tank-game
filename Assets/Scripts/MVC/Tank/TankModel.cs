using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using UnityEngine;

public class TankModel 
{
    private TankScriptableObject tankScriptableObject;
    private int playerID;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;

        playerID = Random.Range(1, 100000);
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
    public float Health { get; set; }
}
