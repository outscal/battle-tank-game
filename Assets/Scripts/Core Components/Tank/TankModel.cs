public class TankModel
{
    public float Speed { get; protected set; }
    public float Health { get; protected set; }

    public float FireRate { get; protected set; }
    public float Damage { get; protected set; }

    public TankModel(float speed, float health, float damage, float fireRate)
    {
        Speed = speed;
        Health = health;
        FireRate = fireRate;
        Damage = damage;
    }
}