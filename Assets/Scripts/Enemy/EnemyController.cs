using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController
{
    public EnemyModel EnemyModel { get; }
    public EnemyView EnemyView { get; }
    private Rigidbody rb;
    public EnemyController(EnemyModel enemyModel, EnemyView enemyPrefab)
    {
        EnemyModel = enemyModel;
        EnemyView = GameObject.Instantiate<EnemyView>(enemyPrefab);
        rb = EnemyView.GetRigidBody();
        EnemyModel.SetEnemyController(this);
        EnemyView.SetEnemyController(this);
    }
}
