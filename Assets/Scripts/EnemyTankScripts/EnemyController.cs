using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    public EnemyModel enemyModel { get; }
    public EnemyView enemyView { get; }
    private Rigidbody rb;
    private Transform playerTransform;
    private Transform gun;
    private Vector3 direction;
    private NavMeshAgent agent;
    private int health;
    private float playerDetectionRange;
    private float distanceToPlayer;
    private float timeSinceShot;

    public EnemyController(EnemyScriptableObject enemy, Vector3 randomPosition, Transform playerTransform, float playerDetectionRange)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemy.enemyView, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        enemyModel = new EnemyModel(enemy);

        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);

        rb = enemyView.GetRigidbody();
        gun = enemyView.GetGun();
        health = enemyModel.health;
        agent = enemyView.GetAgent();
        this.playerTransform = playerTransform;
        this.playerDetectionRange = playerDetectionRange;
    }

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
    public float GetVisibilityRange()
    {
        return enemyModel.visibilityRange;
    }
    public float GetDetectionRange()
    {
        return enemyModel.detectionRange;
    }
    public float GetSpeed()
    {
        return enemyModel.speed;
    }
    public Vector3 GetPosition()
    {
        return enemyView.transform.position;
    }
    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
    public void SetAgentValues()
    {
        agent.speed = enemyModel.speed;
        agent.stoppingDistance = 2f;
    }
    void PlayerDied()
    {
        enemyView.ChangeState(enemyView.enemyIdleState);
    }
    public void SetAttackValues()
    {
        agent.SetDestination(rb.transform.position);
        timeSinceShot = 0f;
    }
    public void Attack()
    {
        if (playerTransform == null)
        {
            PlayerDied();
            return;
        }
        if (Vector3.Distance(rb.transform.position, playerTransform.position) < enemyModel.visibilityRange)
        {
            timeSinceShot += Time.deltaTime;
            if (timeSinceShot > (60 / enemyModel.bpm))
            {
                ShootBullet();
                timeSinceShot = 0;
            }
            direction = (playerTransform.position - rb.transform.position).normalized;
            rb.transform.rotation = Quaternion.Slerp(rb.transform.rotation, Quaternion.LookRotation(direction), 0.2f);
        }
        else
        {
            enemyView.ChangeState(enemyView.enemyChaseState);
        }
    }
    void ShootBullet()
    {
        EnemyService.Instance.ShootBullet(enemyModel.bulletType, gun);
    }
}
