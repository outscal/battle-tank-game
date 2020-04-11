using System.Collections;
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/NewEnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyTankView enemy;
    public string TankName;
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
