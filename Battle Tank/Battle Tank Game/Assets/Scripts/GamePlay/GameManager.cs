using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoGenericSingleton<GameManager>
{
    private float waitTime = 2f;
    private CameraControl m_camera;
    
    void Start()
    {
        m_camera = GameObject.FindObjectOfType<CameraControl>();
    }

    public void DestroyAllGameObjects()
    {
        StartCoroutine(m_camera.ZoomOutCamera());
        StartCoroutine(DestroyAllEnemy()); 
        StartCoroutine(DestroyGround());       
    }


    private IEnumerator DestroyAllEnemy()
    {
        yield return new WaitForSeconds(waitTime);
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTank");

        for(int i = 0; i < enemyObjects.Length; i++)
        {
            enemyObjects[i].GetComponent<EnemyTankView>().enemyTankController.OnDeath();
            yield return new WaitForSeconds(0.05f);            
        }        
    }

    private IEnumerator DestroyGround()
    {
        yield return new WaitForSeconds(waitTime + waitTime);
        GameObject[] obstaclesObjects = GameObject.FindGameObjectsWithTag("Ground");

        for(int i = 0; i < obstaclesObjects.Length; i++)
        {
            Destroy(obstaclesObjects[i]);
            yield return new WaitForSeconds(0.05f);
        }

        GameObject groundPlane = GameObject.FindGameObjectWithTag("GroundPlane");
        Destroy(groundPlane);
    }
}
