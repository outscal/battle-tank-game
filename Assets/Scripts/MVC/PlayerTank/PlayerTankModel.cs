
public class PlayerTankModel
{
    private int Health;
    public int Damage { get; }
    public int Speed { get; }
    public int RotationRate { get; }
    public int TurretRotationRate { get; }

    public PlayerTankModel(int health, int damage, int speed, int rotationRate, int turretRotationRate)
    {
        Health = health;
        Damage = damage;
        Speed = speed;
        RotationRate = rotationRate;
        TurretRotationRate = turretRotationRate;
    }

    public int GetHealth() { return Health; }
    public void SetHealth(int health) { Health = health; }

}
