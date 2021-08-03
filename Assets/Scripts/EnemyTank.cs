using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoSingletonGeneric<EnemyTank>
{
    protected override void Awake()
    {
        base.Awake();
        // Custom logic 
        Debug.Log("Enemy Tank");
    }
}
