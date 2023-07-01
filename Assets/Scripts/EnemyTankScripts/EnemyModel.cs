public class EnemyModel
{
    private EnemyController enemyController;
    public EnemyModel(EnemyScriptableObject enemy)
    {
        speed = enemy.speed;
        health = enemy.health;
        bulletType = enemy.bulletType;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public int speed { get; }
    public int health { get; }
    public BulletType bulletType { get; }
}
