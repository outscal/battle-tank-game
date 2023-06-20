public class TankModel
{
    private TankController tankController;
    public TankModel(float _speed, float _health)
    {
        speed = _speed;
        health = _health;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public float speed { get; }
    public float health { get; }
}
