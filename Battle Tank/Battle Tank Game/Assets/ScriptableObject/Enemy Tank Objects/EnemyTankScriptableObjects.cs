using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObjects", menuName = "ScriptableObjects/NewEnemyTankScriptableObjects")]
public class EnemyTankScriptableObjects : ScriptableObject
{
   //public EnemyTankType tankType;

   public Vector3 scale;
   public string tankName;
   public float tankSpeed;
   public float tankTurnSpeed;
   public float tankHealth;
   public float tankDamage;
   public Color tankColor;
}