
using UnityEngine;

public class PlayerTankModel 
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public float health;

    private TankScriptableObject tankScriptableObject;

    private PlayerTankController tankController;

    public BulletView bulletPrefab;

    public PlayerTankModel(TankScriptableObject tankScriptableObject, BulletView bulletPrefab)
    {
        movementSpeed = tankScriptableObject.movementSpeed;
        rotationSpeed = tankScriptableObject.rotationSpeed;
        health = tankScriptableObject.health;
        this.tankScriptableObject = tankScriptableObject;
        this.bulletPrefab = bulletPrefab;
    }


    public void SetTankController(PlayerTankController _tankController)
    {
        tankController = _tankController;
    }
}
