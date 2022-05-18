using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoBehaviour
{
    public GameObject EnemyTank;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 2, 1 / 2);

        // CancelInvoke("SpawnObject");
    }

    void SpawnObject()
    {
        float X = Random.Range(-25.0f, 25.0f);
        float Z = Random.Range(-25.0f, 25.0f);
        Instantiate(EnemyTank, new Vector3(X, 0, Z), Quaternion.identity);
    }
}

