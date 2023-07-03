using UnityEngine;
public class EnemyController
{
    public EnemyController(EnemyScriptableObject enemy, Vector3 randomPosition)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemy.enemyView, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        enemyModel = new EnemyModel(enemy);

        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);

        rb = enemyView.GetRigidbody();
        health = enemyModel.health;
    }
    public EnemyModel enemyModel { get; }
    public EnemyView enemyView { get; }
    private Rigidbody rb;
    int health;
    public void Shoot(Transform gunTransform)
    {
        EnemyService.Instance.ShootBullet(enemyModel.bulletType, gunTransform);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            TankDeath();
    }
    void TankDeath()
    {
        EnemyService.Instance.DestoryEnemy(this);
    }
    public int GetStrength()
    {
        return enemyModel.strength;
    }
    public Vector3 GetPosition()
    {
        return enemyView.transform.position;
    }
}
