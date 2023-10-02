using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public float Speed { get; private set; }
    public float TurnSpeed { get; private set; }
    public float MaxHealth { get; private set; }
    public float Health { get; set; }
    public float Damage { get; private set; }
    public LayerMask ShellLayer { get; private set; }
    public TankTypes Type { get; private set; }
    public GameObject Explosion { get; set; }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = tankScriptableObject.speed;
        TurnSpeed = tankScriptableObject.turnSpeed;
        Health = MaxHealth = tankScriptableObject.health;
        Damage = tankScriptableObject.damage;
        ShellLayer = tankScriptableObject.shellLayer;
        Type = tankScriptableObject.type;
        Explosion = tankScriptableObject.tankExplosion;
    }
}
