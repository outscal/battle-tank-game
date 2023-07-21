
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/NewEnemyTank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public EnemyTankType TankType;
    public string TankName;
    public int Health;
    public float MovementSpeed;
    public float RotationSpeed;
    public float ChaseRadius;
    public float FightRadius;
}

public enum EnemyTankType
{
    Null,
    Speed,
    Power
}
