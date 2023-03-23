
public class TankModel {
    
    private float movementSpeed;
    private float rotationSpeed;

    public TankModel(float _movementSpeed, float _rotationSpeed)
    {
        movementSpeed = _movementSpeed;
        rotationSpeed = _rotationSpeed;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetRotationSpeed()
    {
        return rotationSpeed;
    }
}
