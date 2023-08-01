public class TankModel
{
    public float Speed { get; }
    public float Health { get; }

    public TankModel(float speed, float health)
    {
        Speed = speed;
        Health = health;
    }
}