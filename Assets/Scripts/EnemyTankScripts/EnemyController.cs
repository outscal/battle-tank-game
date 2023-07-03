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
    int targetIndex;
    Vector3 targetPoint;
    Vector3 direction;
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
    public void SetTargetPosition()
    {
        targetIndex = EnemyService.Instance.GetRandomPatrolPoint(rb.transform.position);
        targetPoint = EnemyService.Instance.GetPatrolPosition(targetIndex);
    }
    public void Patrol()
    {
        if (Vector3.Distance(targetPoint, rb.transform.position) < 2f)
        {
            targetIndex = EnemyService.Instance.GetRandomPatrolPoint(targetIndex);
            targetPoint = EnemyService.Instance.GetPatrolPosition(targetIndex);
        }
        direction = (targetPoint - rb.transform.position).normalized;
        rb.velocity = direction * enemyModel.speed;
        rb.transform.LookAt(direction + rb.transform.position);
    }
}
