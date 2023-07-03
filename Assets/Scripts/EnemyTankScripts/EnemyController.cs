using UnityEngine;
using UnityEngine.AI;
public class EnemyController
{
    public EnemyController(EnemyScriptableObject enemy, Vector3 randomPosition, Transform playerTransform, float playerDetectionRange)
    {
        enemyView = GameObject.Instantiate<EnemyView>(enemy.enemyView, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
        enemyModel = new EnemyModel(enemy);

        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);

        rb = enemyView.GetRigidbody();
        health = enemyModel.health;
        agent = enemyView.GetAgent();
        this.playerTransform = playerTransform;
        this.playerDetectionRange = playerDetectionRange;
    }
    public EnemyModel enemyModel { get; }
    public EnemyView enemyView { get; }
    private Rigidbody rb;
    int health;
    int targetIndex;
    Vector3 targetPoint;
    Vector3 direction;
    NavMeshAgent agent;
    float range = 20f;
    Transform playerTransform;
    float playerDetectionRange;
    float distanceToPlayer;
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
    public void SetAgentValues()
    {
        agent.speed = enemyModel.speed;
        agent.stoppingDistance = 2f;
    }
    public void Patrol()
    {
        if (playerTransform == null)
        {
            PlayerDied();
            return;
        }
        distanceToPlayer = Vector3.Distance(playerTransform.position, rb.transform.position);
        if (distanceToPlayer < playerDetectionRange)
        {
            enemyView.ChangeState(enemyView.enemyChaseState);
        }
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 newPoint;
            if (RandomPoint(rb.transform.position, range, out newPoint))
            {
                Debug.DrawRay(newPoint, Vector3.up, Color.blue, 1.0f);
                agent.destination = newPoint;
            }
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 10.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
    public void SetPlayerAsDestination()
    {
        agent.SetDestination(playerTransform.position);
        agent.stoppingDistance = 0f;
    }
    public void Chase()
    {
        if (playerTransform == null)
        {
            PlayerDied();
            return;
        }
        if (agent.remainingDistance > playerDetectionRange + 10f)
        {
            enemyView.ChangeState(enemyView.enemyIdleState);
        }
        else
        {
            agent.SetDestination(playerTransform.position);
        }
    }
    void PlayerDied()
    {
        enemyView.ChangeState(enemyView.enemyIdleState);
    }
}
