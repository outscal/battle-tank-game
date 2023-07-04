
using System;
using UnityEngine;
[Serializable]
public class PlayerTankModel 
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public float health;


    private PlayerTankController tankController;

    public BulletScriptableObjectList bulletScriptableObjectList;
    public BulletView bulletPrefab;

    public PlayerTankModel(TankScriptableObject tankScriptableObject)
    {
        movementSpeed = tankScriptableObject.movementSpeed;
        rotationSpeed = tankScriptableObject.rotationSpeed;
        health = tankScriptableObject.health;
        bulletScriptableObjectList = tankScriptableObject.bulletScriptableObjectList;
        bulletPrefab = tankScriptableObject.bulletPrefab;
    }


    public void SetTankController(PlayerTankController _tankController)
    {
        tankController = _tankController;
    }
}
