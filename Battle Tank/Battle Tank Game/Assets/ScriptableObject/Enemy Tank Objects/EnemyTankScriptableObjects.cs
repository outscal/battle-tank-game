using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "ScriptableObjects/NewEnemyTankScriptableObjects")]
public class EnemyTankScriptableObjects : ScriptableObject
{
   [Header("Enemy Type")]
   public EnemyTankType tankType;
   
   [Header("Enemy Prefab")]
   public EnemyTankView enemyTankView;
   
   [Header("Health Parameter")]
   public float tankHealth;
   public float tankDamage;
   
   [Header("Movement Parameters")]
   public float tankSpeed;
   public float tankTurnSpeed;
   public float walkPointRange;
   public float patrollingRange;
   public float patrolTime;
   
   [Header("Attack Parameters")]
   public float attackRange;
   public float minLaunchForce;
   public float maxLaunchForce;
}