using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    private EnemyView enemyView;
    private EnemyModel enemyModel;
    
    private object transform;

    public EnemyController(EnemyModel _enemyModel, EnemyView _enemyView , Transform SpawntheEnemy)
    {
        enemyModel = _enemyModel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView,SpawntheEnemy);
        enemyView.SetEnemyController(this);
        enemyModel.SetEnemyController(this);
    }

    public void MoveTowardsPlayer(Transform playerTransform)
    {
                // Calculate the direction towards the player
                Vector3 direction = (playerTransform.position - enemyView.transform.position).normalized;

                // Move the enemy towards the player
                enemyView.GetRigidbody().MovePosition(enemyView.transform.position + direction * enemyModel.Speed * Time.deltaTime);

                // Rotate the enemy to face the player
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                enemyView.GetRigidbody().MoveRotation(targetRotation);
    }
    public void Fire()
    {
        
    }

}
