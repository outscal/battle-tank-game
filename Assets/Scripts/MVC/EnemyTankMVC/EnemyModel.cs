using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private EnemyController enemyConroller;
    private TankTypeScriptableObject tankTypeScriptableObject;

    public TankType TankType { get; }
    public float Speed { get; }
    public int Health { get; }

    public EnemyModel(TankTypeScriptableObject _tankTypeScriptableObject)
    {
        tankTypeScriptableObject = _tankTypeScriptableObject;
        TankType = tankTypeScriptableObject.tankType;
        Speed = tankTypeScriptableObject.speed;
        Health = tankTypeScriptableObject.maxhealth;

    }

    internal void SetEnemyController(EnemyController _enemyConroller)
    {
        enemyConroller = _enemyConroller;
    }
}
