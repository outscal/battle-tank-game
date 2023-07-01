using UnityEngine;
public class EnemyController
{
    public EnemyController(TankScriptableObject tank, float x = 0, float z = 0)
    {
        enemyView = GameObject.Instantiate<EnemyView>(tank.tankView, new Vector3(Random.Range(-x, x), 0, Random.Range(-z, z)), Quaternion.identity);
        enemyModel = new EnemyModel(tank);

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
        TankService.Instance.ShootBullet(enemyModel.bulletType, gunTransform);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
            TankDeath();
    }
    void TankDeath()
    {
        TankService.Instance.DestoryTank(enemyView);
    }
}
