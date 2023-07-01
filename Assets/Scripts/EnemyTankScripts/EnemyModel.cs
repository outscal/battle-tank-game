public class EnemyModel
{
    private EnemyController enemyController;
    public EnemyModel(TankScriptableObject tank)
    {
        speed = tank.speed;
        health = tank.health;
        bulletType = tank.bulletType;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public int speed { get; }
    public int health { get; }
    public BulletType bulletType { get; }
}
