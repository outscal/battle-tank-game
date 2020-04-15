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

[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/EnemyScriptableObjectList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] enemyScriptableObject;
   
}

/// <summary>
/// Bullet Scriptable Object
/// </summary>
/// 
[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObject/BulletScriptableObjectList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bulletScriptableObject;

}

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/BulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType BulletType;
    public int bulletSpeed;

}

/// <summary>
/// Player Tank Scriptable Object
/// </summary>

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/TankScriptableObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tankScriptableObject;

}

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public PlayerTankType TankType;
    public int movingSpeed;
    public int rotatingSpeed;
    public float health;
    public float damage;
    public Color tankColor;

}
