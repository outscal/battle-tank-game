using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Enemy Tank Object", menuName = "Objects/New Enemy Tank Object")]
public class EnemyTankObject : ScriptableObject
{
   [Header("Object Type")]
   public TypeDamagable Type;
   [Header("Tank Properties")]
   public EnemyView enemyView;
   public EnemyType EnemyType;
   public float Speed;
   public int Health;
   public int Damage;
   [Header("Detection parameters")]
   public float DetectionRadius;
   public float EngageRadius;
   public float AttackRadius;
   [Header("Patrol Points")]
   public Vector3[] PatrolPoints;
}
