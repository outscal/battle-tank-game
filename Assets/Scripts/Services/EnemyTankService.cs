using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    EnemyController enemyController;
    [SerializeField] EnemyView enemyView;
    [SerializeField] List<Vector3> spawnPoints;
    [SerializeField] float enemyPatrolSpeed= 4f;
    [SerializeField] float patrolDistance=5f ; //needed to be stored in enemy scriptable object
    //[SerializeField] float EnemyChaseSpeed; to be used in future
    private void Start()
    {
        EnemyModel enemyModel= new EnemyModel(enemyPatrolSpeed, patrolDistance);
        int a = Random.Range(0, spawnPoints.Count) ;
        enemyController = new EnemyController(spawnPoints[a], enemyView, enemyModel);
    }

}
