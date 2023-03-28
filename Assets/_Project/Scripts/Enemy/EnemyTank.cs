using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : GenericSingleton<EnemyTank> {

    protected override void Awake()
    {
        Debug.Log("From EnemyTank Script");
        base.Awake();
    }
}
