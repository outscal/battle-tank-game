using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private float Speed { get; }
    private float Health { get; }
    private float Damage { get; }
    private TankTypes Type { get; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = tankScriptableObject.speed;
        Health = tankScriptableObject.health;
        Damage = tankScriptableObject.damage;
        Type = tankScriptableObject.type;
    }
}
