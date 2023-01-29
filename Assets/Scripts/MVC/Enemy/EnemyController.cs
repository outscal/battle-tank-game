using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    public EnemyType enemyType;

    public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Transform _enemySpawnPos)
    {
        enemyModel = _enemyModel;
        enemyView = _enemyView;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView, _enemySpawnPos);
        enemyView.SetEnemyController(this);

    }


    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }


    public void EnemyMechanism()
    {
        enemyModel.DistanceBetweenTarget = Vector3.Distance(TankService.instance.PlayerPosition().position, enemyView.transform.position);
        if(enemyModel.DistanceBetweenTarget <= enemyModel.EnemyRange)
        {
            enemyView.navMeshAgent.SetDestination(TankService.instance.PlayerPosition().position);
            if (enemyModel.DistanceBetweenTarget <= enemyView.navMeshAgent.stoppingDistance)
            {
                if (enemyModel.CountDownBetweenFire <= 0)
                {
                    foreach (Transform spawnPoints in enemyView.ProjectileSpawnPoint)
                    {
                        TankBulletService.Instance.CreateNewBullet(spawnPoints);
                        //GameObject bulletRigidBody = GameObject.Instantiate(enemyModel.ProjectilePrefab, spawnPoints.position, Quaternion.identity);
                        //bulletRigidBody.GetComponent<Rigidbody>().AddForce(enemyView.transform.forward * 32f, ForceMode.Impulse);
                        enemyView.transform.LookAt(TankService.instance.PlayerPosition().position);
                    }
                    enemyModel.CountDownBetweenFire = 1f / enemyModel.FireRate;
                }
                enemyModel.CountDownBetweenFire -= Time.deltaTime;
            }
        }
    }


    

}
