
public class PlayerTankModel
{
    public int Health { get; }
    public int Damage { get; }
    public int Speed { get; }

    public PlayerTankModel(int health, int damage, int speed)
    {
        Health = health;
        Damage = damage;
        Speed = speed;
    }

}
