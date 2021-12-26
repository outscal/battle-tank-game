using UnityEngine;

public class PlayerTankModel
{
    public int MaxHealth { get; }
    public int Health { get; set; }
    public int Speed { get; }
    public int RotationRate { get; }
    public int TurretRotationRate { get; }

    public Color FullHealthColor = Color.green;
    public Color ZeroHealthColor = Color.red;

    public bool b_IsDead { get; set; }

    public PlayerTankModel(int health, int speed, int rotationRate, int turretRotationRate)
    {
        b_IsDead = false;
        MaxHealth = health;
        Health = health;
        Speed = speed;
        RotationRate = rotationRate;
        TurretRotationRate = turretRotationRate;
    }

}
