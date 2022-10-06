using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    EnemyController enemyController;
    [SerializeField] EnemyView enemyView;
    [SerializeField] List<Vector3> spawnPoints;
    //[SerializeField] float EnemyChaseSpeed; to be used in future
    private void Start()
    {
        EnemyModel enemyModel= new EnemyModel(spawnPoints);
        int a = Random.Range(0, spawnPoints.Count) ;
        enemyController = new EnemyController(spawnPoints[a], enemyView, enemyModel);
    }

}
