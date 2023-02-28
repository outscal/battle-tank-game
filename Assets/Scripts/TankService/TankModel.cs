
public class TankModel
{
    public TankModel(int speed, int rotateSpeed, float jumpForce)
    {
        Speed = speed;
        RotateSpeed = rotateSpeed;
        JumpForce = jumpForce;
    }

    // read-only properties
    public int Speed { get; }
    public int RotateSpeed { get; }
    public float JumpForce { get; }
};
