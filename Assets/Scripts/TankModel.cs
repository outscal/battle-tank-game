
using UnityEngine;
public class TankModel
{
    private TankController tankController;
    public float movementSpeed;
    public float rotationSpeed;
    public TankType tankType;
    public BulletType bulletType;

    public TankModel(float _movementSpeed, float _rotationSpeed, TankType _tankType, BulletType _bulletType)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
        tankType = _tankType;
        bulletType = _bulletType;
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
}
