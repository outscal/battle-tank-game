using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class stores and is referred to acces the data of a Tank entity in the game.
/// </summary>
public class TankModel : TankScriptableObject
{
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        Speed = tankScriptableObject.speed;
        Health = tankScriptableObject.health;
        RotationSpeed = tankScriptableObject.rotationSpeed;
        TankName = tankScriptableObject.TankName;
        TurretRotationSpeed = tankScriptableObject.TurretRotationSpeed;
        //BulletType = tankScriptableObject.bulletType;
    }

    public float Speed { get; }
    public int Health { get; }
    public float RotationSpeed { get; }
    public string TankName { get; }
    public float TurretRotationSpeed { get; }
    //public BulletType BulletType { get; }
}