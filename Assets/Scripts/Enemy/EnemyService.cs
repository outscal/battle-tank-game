using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyService : SingletonGeneric<EnemyService>
{
    [SerializeField] private EnemyScriptableObjectList enemyScriptableObjectList;
    [SerializeField] private int numberOfEnemies = 5;

    private void Start()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            CreateNewEnemy();
        }       
    }
    private EnemyController CreateNewEnemy()
    {
        int randomNumber = (int)Random.Range(0, enemyScriptableObjectList.enemies.Length);
        EnemyScriptableObject enemyObject = enemyScriptableObjectList.enemies[randomNumber];
        Debug.Log("Created enemy of type: " + enemyObject.name);
        EnemyModel model = new(enemyObject);
        EnemyController enemy = new(model, enemyObject.enemyView);
        return enemy;
    }
}

