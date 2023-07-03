using UnityEngine;
using UnityEngine.AI;
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
        agent = enemyView.GetAgent();
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
    /*
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
    */
    public void SetAgentValues()
    {
        agent.speed = enemyModel.speed;
        agent.stoppingDistance = 2f;
    }
    public void Patrol()
    {
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
}
