using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyConroller enemyConroller;
    private Transform playertransform;
    void Start()
    {
        Transform transform1 = GameObject.FindGameObjectWithTag("Player").transform;
        playertransform = transform1;
    }

    // Update is called once per frame
    void Update()
    {
        enemyConroller.MoveTowardsPlayer(playertransform);
    }

    internal void SetEnemyController(EnemyConroller _enemyConroller)
    {
        enemyConroller = _enemyConroller;
    }
}
