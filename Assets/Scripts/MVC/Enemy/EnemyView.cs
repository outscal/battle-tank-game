using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    public EnemyController enemyController;
    public EnemyType enemyType;
    public Transform[] ProjectileSpawnPoint;
    public NavMeshAgent navMeshAgent;
    public GameObject deathEffect;
    protected TankState currentSate;
    [SerializeField]
    public TankPatrollingState patrolingState;
    [SerializeField]
    public TankChasingState chasingState;
    public TankState startingState;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ChangeState(startingState);
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

    public void ChangeState(TankState newState)
    {
        if(currentSate != null)
        {
            currentSate.OnExitState();
        }
        currentSate = newState;
        currentSate.OnEnterState();
    }
}

