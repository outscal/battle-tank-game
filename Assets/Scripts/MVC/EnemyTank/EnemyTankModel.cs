
using UnityEngine;

public class EnemyTankModel
{
    public int Health { get; }
    public int Damage { get; }
    public int Speed { get; }

    public EnemyTankModel(int health, int damage, int speed)
    {
        Health = health;
        Damage = damage;
        Speed = speed;
    }

}
