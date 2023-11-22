using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    private EnemyController _enemyController;
    public EnemyType enemyType{get;}
    // public int Speed{get;}
    public int Speed = 5;
    public float Health;

    public EnemyModel(EnemyScriptableObject enemyScriptableObject){
        enemyType = enemyScriptableObject.enemyType;  
        Speed = (int)enemyScriptableObject.Speed;
        Health = enemyScriptableObject.Health;
    }

    public void SetEnemyController(EnemyController enemyController){
        _enemyController = enemyController;
    }

}
