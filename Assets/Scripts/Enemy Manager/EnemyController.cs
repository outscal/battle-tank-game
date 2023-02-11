using UnityEngine;
using UnityEngine.AI;
public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private Rigidbody rb;
    private NavMeshAgent enemyTank;
    private Transform[] patrol;
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
            int i = Random.Range(0,patrol.Length-1);
            enemyTank.SetDestination(patrol[i].position);
        }
    }
    public void MoveToPlayer(Transform target)
    {
        enemyTank.destination = target.position;
        enemyTank.stoppingDistance = 10f;
        Vector3 newDirection = Vector3.RotateTowards(rb.transform.forward, target.position - rb.transform.position, 0.5f, 0.0f);
        rb.transform.rotation = Quaternion.LookRotation(newDirection);
        if(enemyTank.remainingDistance <= enemyTank.stoppingDistance)
        // if(Vector3.Distance(rb.transform.position, target.transform.position) <= 5f)
        {
        //     rb.velocity = Vector3.zero;
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
            DestroySequence.Instance.WaveComplete(rb.transform);
            //startSequence.PlayerDeath();
        }
    }
}
