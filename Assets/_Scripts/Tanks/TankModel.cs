using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankType TankType { get; }
    public int Speed { get; }
    public float Health { get; }
    public int SpeedLive {get { return (int)tankScriptableObject.Speed; } }

    private TankController tankController;
    private TankScriptableObject tankScriptableObject;
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
    }
    public TankModel(TankType tankType, int speed, float health)
    {
        TankType = tankType;
        Speed = speed;
        Health = health;
    }


}
