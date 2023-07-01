
using UnityEngine;

public class TankModel 
{
    public float movementSpeed { get; private set; }
    public float rotationSpeed { get; private set; }

    public float health;

    private TankScriptableObject tankScriptableObject;

    private TankController tankController;

    public TankModel(TankScriptableObject tankScriptableObject)
    {
        movementSpeed = tankScriptableObject.movementSpeed;
        rotationSpeed = tankScriptableObject.rotationSpeed;
        health = tankScriptableObject.health;
        this.tankScriptableObject = tankScriptableObject;
    }
    public TankModel(float _movementSpeed, float _rotationSpeed)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
    }


    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
