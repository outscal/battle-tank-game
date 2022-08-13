using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    // TankModel -> controller
    public void SetTankControllerReference(TankController _tankController)
    {
        tankController = _tankController;
    }

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.tankType;
        RotationSpeed = tankScriptableObject.rotationSpeed;
        MovementSpeed = tankScriptableObject.speed;
        Health = tankScriptableObject.health;
        RotationSpeed = tankScriptableObject.rotationSpeed;
        TankName = tankScriptableObject.tankName;
        //TurretRotationSpeed = tankScriptableObject.TurretRotationSpeed;
        //BulletType = tankScriptableObject.bulletType;
        //BulletsFired = tankScriptableObject.bulletsFired;
        //EnemiesKilled = tankScriptableObject.enemiesKilled;
    }

    public float MovementSpeed { get; }
    public TankType TankType { get; }
    public int Health { get; set; }
    public float RotationSpeed { get; }
    public string TankName { get; }
    //public float TurretRotationSpeed { get; }
    //public BulletType BulletType { get; }
    //public int BulletsFired { get; set; }
    //public int EnemiesKilled { get; set; }
}
