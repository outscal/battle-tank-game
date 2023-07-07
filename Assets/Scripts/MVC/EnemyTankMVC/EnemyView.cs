using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private EnemyController enemyConroller;
    private TankView tankTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
   // void Update() => enemyConroller.MoveTowardsPlayer(tankTransform.GetTransform());

    internal void SetEnemyController(EnemyController _enemyConroller)
    {
        enemyConroller = _enemyConroller;
    }
    
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
