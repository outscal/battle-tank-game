using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public float tank_Speed { get; private set; }
    public float tank_TurnSpeed { get; private set; }
    public float tank_Health { get; private set; }
    public float tank_Damage { get; private set; }
    public TankTypes tank_Type { get; private set; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        tank_Speed = tankScriptableObject.speed;
        tank_TurnSpeed = tankScriptableObject.turnSpeed;
        tank_Health = tankScriptableObject.health;
        tank_Damage = tankScriptableObject.damage;
        tank_Type = tankScriptableObject.type;
    }
}
