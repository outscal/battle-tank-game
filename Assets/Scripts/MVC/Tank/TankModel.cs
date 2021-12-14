using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    public TankModel(TankType tankType,int speed, float health)
    {
        TankType = tankType;
        Speed = speed;
        Health = health;
    }

    public TankType TankType { get; }
    public int Speed { get; private set; }
    public float Health { get; private set; }
}
