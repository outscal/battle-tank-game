using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Tank Object", menuName = "Objects/New Enemy Tank Object")]
public class EnemyTankObject : ScriptableObject
{
   public TankView tankView;
   public TankType tankType;
   public float moveSpeed;
   public float TurnSpeed;
   public int Health;
   public int Damage;
}
