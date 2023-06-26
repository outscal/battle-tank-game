
using UnityEngine;

public class TankModel 
{
    public float movementSpeed { get; }
    public float rotationSpeed { get; }

    private TankController tankController;

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
