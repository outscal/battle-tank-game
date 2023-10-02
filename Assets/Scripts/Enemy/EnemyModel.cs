using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel
{
    public float Speed { get; private set; }
    public float TurnSpeed { get; private set; }
    public float MaxHealth { get; set; }
    public float Health { get; set; }
    public float Damage { get; private set; }
    public float FireRate { get; private set; }
    public float DetectionRadius { get; private set; }
    public float AttackRange { get; private set; }
    public float FieldOfView { get; private set; }
    public LayerMask ShellLayer { get; private set; }
    public EnemyTypes Type { get; private set; }
    public GameObject Explosion { get; set; }

    public EnemyModel(EnemyScriptableObject enemyScriptableObject)
    {
        Speed = enemyScriptableObject.speed;
        TurnSpeed = enemyScriptableObject.turnSpeed;
        MaxHealth = Health = enemyScriptableObject.health;
        Damage = enemyScriptableObject.damage;
        FireRate = enemyScriptableObject.fireRate;
        DetectionRadius = enemyScriptableObject.detectionRadius;
        AttackRange = enemyScriptableObject.attackRange;
        FieldOfView = enemyScriptableObject.fieldOfView;
        ShellLayer = enemyScriptableObject.shellLayer;
        Type = enemyScriptableObject.type;
        Explosion = enemyScriptableObject.enemyExplosion;
    }
}
