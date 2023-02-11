using UnityEngine;
using UnityEngine.AI;
public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private Rigidbody rb;
    private NavMeshAgent enemyTank;
    private Transform[] patrol;
    private DestroySequence startSequence ;
    public EnemyController(EnemyModel enemymodel, EnemyView enemyview, Transform spawnTransform, Transform[] patrolDestination)
    {
        patrol = patrolDestination;
        this.enemyModel = enemymodel;
        enemyView = GameObject.Instantiate<EnemyView>(enemyview, spawnTransform.position,Quaternion.identity);
        rb = enemyView.GetComponent<Rigidbody>();
        enemyTank = enemyView.GetComponent<NavMeshAgent>();
        this.enemyView.SetEnemyController(this);
        this.enemyModel.SetEnemyController(this);
    }
    public void Move()
    {
        if(enemyTank.remainingDistance <= enemyTank.stoppingDistance)
        { 
            int i = Random.Range(0,patrol.Length);
            enemyTank.SetDestination(patrol[i].position);
        }
    }
    public void Turn()
    {
        float turn = 1 * enemyModel.TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public void MoveToPlayer(Transform target)
    {
        // float zero = 0;
        // var step =  enemyModel.speed * Time.deltaTime;
        // rb.transform.position = Vector3.MoveTowards(rb.transform.position, target.position, step);
        enemyTank.destination = target.position;
        enemyTank.stoppingDistance = 5f;
        Vector3 newDirection = Vector3.RotateTowards(rb.transform.forward, target.position - rb.transform.position, 0.5f, 0.0f);
        rb.transform.rotation = Quaternion.LookRotation(newDirection);
        if(enemyTank.remainingDistance <= 5.0f)
        {
            rb.velocity = Vector3.zero;
            Fire();
        }
    }
    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }
    public void Fire()
    {
        enemyView.bulletSpawner.SpawnBullet(enemyView.bulletSpawner.transform);
    }
    public void GetDamage(float damage)
    {
        enemyModel.Health -= damage;
        if(enemyModel.Health <= 0)
        {
            enemyView.DestroyObj();
            startSequence.PlayerDeath();
        }
    }
}
