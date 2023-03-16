using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyType enemyType;
    public Transform[] ProjectileSpawnPoint;
    public NavMeshAgent navMeshAgent;
    public GameObject deathEffect;
   

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();  
    }

   
    void Update()
    {
        if(enemyController.enemyModel.Health <= 0)
        {
            Destroy(this);
        }
    }

    public void SetEnemyController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<TankBulletView>())
        {
            enemyController.enemyModel.Health = enemyController.enemyModel.Health - collision.gameObject.GetComponent<TankBulletView>().GetDamage();
            Debug.Log(" Enemy health: " + enemyController.enemyModel.Health);
        }
    }

   
}

