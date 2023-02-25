using UnityEngine;

public class EnemyModel
{
    private EnemyController enemyController;
    public EnemyType type;
    public float Health;
    public float speed;
    public float TurnSpeed = 15f;
    public EnemyModel (EnemyTankObject tank)
    {
        Health = tank.Health;
        speed = tank.moveSpeed;
    }
    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }
}
