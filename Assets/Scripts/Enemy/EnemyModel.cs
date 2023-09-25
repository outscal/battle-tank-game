using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public float enemy_Speed { get; private set; }
    public float enemy_TurnSpeed { get; private set; }
    public float enemy_Health { get; private set; }
    public float enemy_Damage { get; private set; }
    public EnemyTypes enemy_Type { get; private set; }

    public EnemyModel(EnemyScriptableObject enemyScriptableObject)
    {
        enemy_Speed = enemyScriptableObject.speed;
        enemy_TurnSpeed = enemyScriptableObject.turnSpeed;
        enemy_Health = enemyScriptableObject.health;
        enemy_Damage = enemyScriptableObject.damage;
        enemy_Type = enemyScriptableObject.type;
    }
}
