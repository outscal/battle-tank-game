using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankScriptableObject tankScriptableObject;

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        this.tankScriptableObject = tankScriptableObject;
        TankTypes = tankScriptableObject.TankTypes;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
    }
    public TankModel(TankTypes tanktypes, int speed, float health)
    {
        TankTypes = tanktypes;
        Speed = speed;
        Health = health;
    }
    public TankTypes TankTypes { get; }
    public int Speed { get; }
    public float Health { get; }
    public int SpeedLive { get { return (int)tankScriptableObject.Speed; } }
}
