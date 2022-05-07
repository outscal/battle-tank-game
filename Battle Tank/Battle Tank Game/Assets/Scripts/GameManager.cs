using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoGenericSingleton<GameManager>
{
    private float waitTime = 2f;
    public void DestroyAllGameObjects()
    {
        StartCoroutine(DestroyAllEnemy()); 
        StartCoroutine(DestroyGround());       
    }


    private IEnumerator DestroyAllEnemy()
    {
        yield return new WaitForSeconds(waitTime);

        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemyObjects.Length; i++)
        {
            enemyObjects[i].GetComponent<EnemyTankView>().enemyTankController.OnDeath();
        }        
    }

    private IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(waitTime);

        GameObject[] obstaclesObjects = GameObject.FindGameObjectsWithTag("Ground");

        for(int i = 0; i < obstaclesObjects.Length; i++)
        {
            Destroy(obstaclesObjects[i]);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
