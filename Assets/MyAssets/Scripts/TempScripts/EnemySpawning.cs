using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{

    public GameObject enemyPrefab;
    private Vector3 position;
    // public BoxCollider boxCollider;
    private int count = 0;
    private float timer = 0;
    private float spwanTime = 5f;
    private float maxX, maxZ, minX, minZ;
    // private IEnumerator
    // public Transform[] enemyPos;
    public List<Transform> enemyPos;
    void Start()
    {
        count = 0;
        // boxCollider = GetComponent<BoxCollider>();
        // maxX = boxCollider.bounds.max.x;
        // maxZ = boxCollider.bounds.max.z;
        // minX = boxCollider.bounds.min.x;
        // minZ = boxCollider.bounds.min.z;

        StartCoroutine(SpwanWaiting());
        // Invoke("SpawningEnemy", 0.2f);
        count++;
    }


    // void SpawningEnemy()
    // {
    //     for (int i = 0; i < enemyPos.Length; i++)
    //     {

    //         Instantiate(enemyPrefab, enemyPos[num].position, Quaternion.identity);
    //     }
    //     enemyPos.RemoveAt(nu)
    // }


    void SpawningEnemy()
    {
        int num = Random.Range(0, enemyPos.Count);
        // float x = Random.Range(minX, maxX);
        // float z = Random.Range(minZ, maxZ);
        // Vector3 randomPosition = new Vector3(x, 0, z);
        Instantiate(enemyPrefab, enemyPos[num].position, Quaternion.identity);
        enemyPos.RemoveAt(num);
    }


    IEnumerator SpwanWaiting()
    {
        SpawningEnemy();
        yield return new WaitForSeconds(2f);

        if (count >= 5)
        {
            StopCoroutine(SpwanWaiting());
        }
        else
        {
            StartCoroutine(SpwanWaiting());
        }

        count++;
    }
}
