using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private EnemyConroller enemyConroller;
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

    internal void SetEnemyController(EnemyConroller _enemyConroller)
    {
        enemyConroller = _enemyConroller;
    }
}
