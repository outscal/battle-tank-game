public class TankModel
{
    private TankController tankController;
    public TankModel(TankScriptableObject tank)
    {
        speed = tank.speed;
        health = tank.health;
        damage = tank.damage;
    }
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public float speed { get; }
    public float health { get; }
    public float damage { get; }
}
