
using UnityEngine;

public class TankModel 
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public float health;

    private TankScriptableObject tankScriptableObject;

    private TankController tankController;

    private GameObject bulletPrefab;

    public TankModel(TankScriptableObject tankScriptableObject, GameObject bulletPrefab)
    {
        movementSpeed = tankScriptableObject.movementSpeed;
        rotationSpeed = tankScriptableObject.rotationSpeed;
        health = tankScriptableObject.health;
        this.tankScriptableObject = tankScriptableObject;
        this.bulletPrefab = bulletPrefab;
    }


    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
