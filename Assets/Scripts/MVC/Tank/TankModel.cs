public class TankModel
{
    TankController m_tankController;

    private int m_Speed;
    private float m_Health;

    public TankModel(int speed, float health)
    {
        Health = health;
        Speed = speed;
    }

    public int Speed { get; }
    public float Health { get; }

    public void SetTankController(TankController tankController)
    {
        m_tankController = tankController;
    }
}