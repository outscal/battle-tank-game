using Tanks.ObjectPool;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    public Rigidbody rb;
    private NavMeshAgent enemyTank;
    public Vector3[] patrolPoints;
    public EnemyController(EnemyModel enemymodel, EnemyView enemyview, Vector3[] patrolDestination)
    {
        patrolPoints = patrolDestination;
        this.enemyModel = enemymodel;
        enemyView = GameObject.Instantiate<EnemyView>(enemyview, patrolDestination[Random.Range(0, patrolDestination.Length - 1)],Quaternion.identity);
        rb = enemyView.GetComponent<Rigidbody>();
        enemyTank = enemyView.GetComponent<NavMeshAgent>();
        this.enemyView.SetEnemyController(this);
        this.enemyModel.SetEnemyController(this);
    }
    public void GetDamage(float damage)
    {
        enemyModel.Health -= damage;
        if(enemyModel.Health <= 0)
        {
            enemyView.DestroyObj();
            //DestroySequence.Instance.WaveComplete(rb.transform);
            //startSequence.PlayerDeath();
        }
    }
    private void OnDisable() {
        EnemyPool.Instance.ReturnItem(this);
    }
    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }
    
}
