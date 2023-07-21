using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public EnemyController(EnemyScriptableObject enemy, float x = 0, float z = 0)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemy.enemyView, new Vector3(Random.Range(-x, x), 0, Random.Range(-z, z)), Quaternion.identity);
        enemyModel = new EnemyModel(enemy);

        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);

        rb = enemyView.GetRigidbody();
        health = enemyModel.health;
    }
    public EnemyModel enemyModel { get; }

    internal object GetAgent()
    {
        throw new System.NotImplementedException();
    }

    public EnemyView enemyView { get; }
    private Rigidbody rb;
    int health;
    internal object spawnPoint;

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
