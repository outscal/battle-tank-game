using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class EnemyController
{
    EnemyView enemyView;
    EnemyModel enemyModel;
    bool isDisabled=false;
    NavMeshAgent navMeshAgent;
    int tempIndex = 0;
    Vector3 currDestination;

    public EnemyController(Vector3 spawnPoint,EnemyView _enemyView, EnemyModel _enemyModel)
    {
        enemyView = _enemyView;
        Vector3 tempPos = enemyView.gameObject.transform.position;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView, spawnPoint, Quaternion.identity);
        enemyModel= _enemyModel;
        navMeshAgent= enemyView.GetComponent<NavMeshAgent>(); 
        enemyView.LinkController(this);
    }


    public void Patrol(Vector3 currPos)
    {
        if(currPos.z== currDestination.z && currPos.x==currDestination.x)
        {
            tempIndex = Random.Range(0, enemyModel.GetCount());
            currDestination= enemyModel.GetPoint(tempIndex);
        }
        navMeshAgent.destination = currDestination;
    }

    public void DisableEnemy(List<MeshRenderer> meshRenderers)
    {
        isDisabled = true;
        enemyView.gameObject.GetComponent<BoxCollider>().enabled = false;
        enemyView.gameObject.GetComponent<ParticleSystem>().Play();
        for(int i=0;i<meshRenderers.Count;i++)
        {
            meshRenderers[i].enabled = false;
        }
    }

    public void DestroyEnemy()
    {
        GameObject.Destroy(enemyView.gameObject);
    }

}
