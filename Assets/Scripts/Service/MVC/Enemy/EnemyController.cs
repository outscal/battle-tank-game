using Tanks.ObjectPool;
using UnityEngine;
using UnityEngine.AI;
using Tank.EventService;

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
    public void GetDamage(float damage, TypeDamagable type)
    {
        if(enemyModel.Type == type)
            return;
        enemyModel.Health -= damage;
        if(enemyModel.Health <= 0)
        {
            DestroyObj();
            EventManagement.Instance.EnemyDeath();
        }
    }
    private void DestroyObj() {
        EnemyPool.Instance.ReturnItem(this);
            enemyView.gameObject.SetActive(false);
    }
    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }
    public void  ActivateEnemy()
    {
        var spawn = patrolPoints[Random.Range(0,patrolPoints.Length - 1)]; 
        enemyView.gameObject.SetActive(true);
        enemyModel.RestoreHealth();
//        enemyView.GetComponent<MeshRenderer>().enabled = true;
        enemyView.gameObject.transform.position = spawn;
    }
}
