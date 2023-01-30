using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public EnemyType enemyType;
    public Transform[] ProjectileSpawnPoint;
    public NavMeshAgent navMeshAgent;
    public GameObject deathEffect;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyController.enemyModel.Health > 0)
        {
            enemyController.EnemyMechanism();
        }
        else
        {
            Destroy(this.gameObject);
           // Debug.Log("Enemy is dead");
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
           // Debug.Log(" Player health: " + enemyController.enemyModel.Health);
        }
    }
}

