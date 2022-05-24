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
        TankHealth = tankScriptableObject.health;
        RotationSpeed = tankScriptableObject.rotationSpeed;
        TankName = tankScriptableObject.TankName;
        TurretRotationSpeed = tankScriptableObject.TurretRotationSpeed;
        BulletType = tankScriptableObject.bulletType;
        MinLaunchForce = tankScriptableObject.minLaunchForce;
        MaxLaunchForce = tankScriptableObject.maxLaunchForce;
        MaxChargeTime = tankScriptableObject.maxChargeTime;
        CurrentLaunchForce = tankScriptableObject.currentLaunchForce;
    }

    public float Speed { get; }
    public int TankHealth { get; }
    public float RotationSpeed { get; }
    public new string TankName { get; }
    public new float TurretRotationSpeed { get; }
    public BulletType BulletType { get; }
    public float MinLaunchForce { get; }

    internal float currentHealth;
    public float MaxLaunchForce { get; }
    public float MaxChargeTime { get; }
    public float CurrentLaunchForce { get; set; }
    //
    public int EnemiesKilled { get; set; }

    public int BulletsFired { get; set; }




}