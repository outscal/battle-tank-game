

public class EnemyModel 
{
    private EnemyController _EnemyController;
    private EnemyScriptableObject _EnemyScriptableObject;
    public int speed { get; }
    public int health { get; }
    public EnemyType type { get; }
    public EnemyModel(EnemyScriptableObject enemySO)
    {
        _EnemyScriptableObject = enemySO;
        speed=enemySO.speed;
        health = enemySO.health;
        type = enemySO.type;
    }
    public void SetEnemyController(EnemyController enemyController)
    {
        _EnemyController = enemyController;
    }
    public int SpeedLive { get { return (int)_EnemyScriptableObject.speed; } }
}
