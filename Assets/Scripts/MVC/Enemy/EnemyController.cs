using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    public EnemyType enemyType;

    int waypointIndes;
    Vector3 target;

    public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView, Transform _enemySpawnPos)
    {
        enemyModel = _enemyModel;
        enemyView = _enemyView;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView,_enemySpawnPos);
        enemyView.SetEnemyController(this);
    }

   

    public void UpdateDestination()
    {
        Debug.Log("In Update Destination");
        target = enemyModel.WayPoints[waypointIndes].position;
        enemyView.agent.SetDestination(target);
    }
  

   
    public void IterateWayPointIndex()
    {
        Debug.Log("In Iterate Wap PointIndex");
        waypointIndes++;
        if(waypointIndes == enemyModel.WayPoints.Length)
        {
            waypointIndes = 0;
        }
    }
    
    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }

    public  Vector3 GetTarget()
    {
        return target;
    }

    public int GetWayPointIndex()
    {
        return waypointIndes;
    }
}
