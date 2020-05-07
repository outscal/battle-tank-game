using System.Collections;
using System;
using UnityEngine;

/// <summary>
/// Enemy Tank Scriptable Object
/// </summary>

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/NewEnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyTankType EnemyType;
    public int FireRateDelay;
    public string TankName;
    public float TankDamge;
    public int TankSpeed;
    public int TankRotationSpeed;
    public float TankHealth;
    public Color TankColor;
}

/// <summary>
/// Bullet Scriptable Object
/// </summary>
/// 


/// <summary>
/// Player Tank Scriptable Object
/// </summary>

