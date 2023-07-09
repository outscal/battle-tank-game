public class EnemyModel
{
    private EnemyController enemyController;
    public EnemyModel(EnemyScriptableObject enemy)
    {
        speed = enemy.speed;
        health = enemy.health;
        strength = enemy.strength;
        bpm = enemy.bpm;
        visibilityRange = enemy.visibilityRange;
        detectionRange = enemy.detectionRange;
        bulletType = enemy.bulletType;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
    public int speed { get; }
    public int health { get; }
    public int strength { get; }
    public int bpm { get; }
    public float visibilityRange { get; }
    public float detectionRange { get; }
    public BulletType bulletType { get; }
}
