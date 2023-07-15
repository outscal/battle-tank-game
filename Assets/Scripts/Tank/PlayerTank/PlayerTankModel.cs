
using System;
using UnityEngine;
[Serializable]
public class PlayerTankModel 
{
    public float MovementSpeed { get; private set; }
    public float RotationSpeed { get; private set; }

    public float health;


    private PlayerTankController tankController;

    public BulletScriptableObjectList bulletScriptableObjectList;
    public BulletView bulletPrefab;

    public PlayerTankModel(PlayerTankScriptableObject tankScriptableObject)
    {
        MovementSpeed = tankScriptableObject.MovementSpeed;
        RotationSpeed = tankScriptableObject.RotationSpeed;
        health = tankScriptableObject.Health;
    }


    public void SetTankController(PlayerTankController tankController)
    {
        this.tankController = tankController;
    }
}
