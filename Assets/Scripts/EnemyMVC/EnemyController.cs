using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using TankServices;
public class EnemyController
{
    EnemyView enemyView;
    EnemyModel enemyModel;
    bool isDisabled = false;
    NavMeshAgent navMeshAgent;
    int tempIndex = 0;
    Vector3 currDestination;

    public EnemyController(Vector3 spawnPoint, EnemyView _enemyView, EnemyModel _enemyModel)
    {
        enemyView = _enemyView;
        Vector3 tempPos = enemyView.gameObject.transform.position;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView, spawnPoint, Quaternion.identity);
        enemyModel = _enemyModel;
        enemyView.GetComponent<PatrolState>().OnEnterState();
        enemyView.LinkController(this);
        ServiceEvents.Instance.ChasePlayer += ChasePlayer ;
        ServiceEvents.Instance.StopChase += StopChasePlayer;
    }


    public void StopChasePlayer()
    {
        enemyView.GetComponent<ChaseState>().OnExitState();
        enemyView.GetComponent<PatrolState>().OnEnterState();
    }

    public void ChasePlayer()
    {
        enemyView.GetComponent<PatrolState>().OnExitState();
        enemyView.GetComponent<ChaseState>().OnEnterState();
    }

    public void DisableEnemy(List<MeshRenderer> meshRenderers)
    {
        isDisabled = true;
        enemyView.gameObject.GetComponent<BoxCollider>().enabled = false;
        enemyView.gameObject.GetComponent<ParticleSystem>().Play();
        for (int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].enabled = false;
        }
    }

    public void DestroyEnemy()
    {
        GameObject.Destroy(enemyView.gameObject);
    }

}
