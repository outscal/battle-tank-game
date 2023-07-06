using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConroller
{
    private EnemyView enemyView;
    private EnemyModel enemyModel;
     

    public EnemyConroller(EnemyModel _enemyModel, EnemyView _enemyView , Transform SpawntheEnemy)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView,SpawntheEnemy);
        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);
    }

    public void MoveTowardsPlayer(Transform playerTank)
    {
        if (playerTank != null)
        {
            Vector3 direction = playerTank.position - enemyModel.transform.position;
            enemyModel.transform.Translate(direction.normalized * enemyModel.Speed * Time.deltaTime);
        }
    }
    public void Fire()
    {
        // Implement your bullet firing logic here
    }

}
