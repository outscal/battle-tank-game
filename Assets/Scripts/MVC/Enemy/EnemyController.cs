using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    public EnemyModel enemyModel;
    private EnemyView enemyView;
    public EnemyType enemyType;
    int _currentWaypoint;

    protected TankState currentSate;
    public int destPoints = 0;


    public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Transform _enemySpawnPos)
    {
        enemyModel = _enemyModel;
        enemyView = _enemyView;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView, _enemySpawnPos);
        enemyView.SetEnemyController(this);
        ChangeState(enemyView.GetComponent<TankChasingState>());
    }


    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }


    public void Patrolling()
    {
        if (enemyView.navMeshAgent.remainingDistance < 1f)
        {
            if (destPoints >= enemyModel.Waypoints.Length - 1)
            {
                destPoints = 0;
            }
            else
            {
                destPoints++;
            }
            enemyView.navMeshAgent.SetDestination(enemyModel.Waypoints[destPoints].transform.position);
        }
    }

    public bool IsPatrolling()
    {
        Transform wp = enemyModel.Waypoints[_currentWaypoint];
        return Vector3.Distance(enemyView.transform.position, wp.position) < 0.01f;
    }

    public void ChasingPlayer()
    {
        enemyView.transform.LookAt(TankService.instance.PlayerPosition().position);
        enemyView.navMeshAgent.SetDestination(TankService.instance.PlayerPosition().position);
    }

    public bool IsInChaseRange()
    {

        return DistanceBetTanks() <= enemyModel.ChaseRange;
    }

    public void Shooting()
    {
        if (enemyModel.CountDownBetweenFire <= 0)
        {
            foreach (Transform spawnPoints in enemyView.ProjectileSpawnPoint)
            {
                TankBulletService.Instance.CreateNewBullet(spawnPoints);

            }
            enemyModel.CountDownBetweenFire = 1f / enemyModel.FireRate;
        }
        enemyModel.CountDownBetweenFire -= Time.deltaTime;
    }

    public bool IsInShootingRange()
    {
        return DistanceBetTanks() <= enemyModel.ShootRange; // chnage naming
    }

    public void ChangeState(TankState newState)
    {
        if (currentSate != null)
        {
            currentSate.OnExitState();
        }
        currentSate = newState;
        currentSate.OnEnterState();
    }


    public NavMeshAgent EnemyNavMeshAgent()
    {
        return enemyView.navMeshAgent;
    }

    private float DistanceBetTanks()
    {
        if (enemyView == null)
        {
            return Mathf.Infinity;
        }
        return Vector3.Distance(TankService.instance.PlayerPosition().position, enemyView.transform.position);
    }
}
