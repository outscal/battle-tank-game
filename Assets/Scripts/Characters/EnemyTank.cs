using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Characters<EnemyTank>
{
    public void EnemyTankinit()
    {
        print("Enemy tank initiated");
    }
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Enemy Awake Override");
    }
}
