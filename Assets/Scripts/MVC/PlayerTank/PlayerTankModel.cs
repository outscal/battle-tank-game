
public class PlayerTankModel
{
    public int Health { get; set; }
    public int Speed { get; }
    public int RotationRate { get; }
    public int TurretRotationRate { get; }

    public PlayerTankModel(int health, int speed, int rotationRate, int turretRotationRate)
    {
        Health = health;
        Speed = speed;
        RotationRate = rotationRate;
        TurretRotationRate = turretRotationRate;
    }

}
