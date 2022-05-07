using UnityEngine;

public class TankModel 
{
    private TankController tankController;

    public float movementSpeed;
    public float rotateSpeed;

    public TankModel(float _movementSpeed, float _rotateSpeed)
    {
       movementSpeed = _movementSpeed;
       rotateSpeed = _rotateSpeed;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }
}
