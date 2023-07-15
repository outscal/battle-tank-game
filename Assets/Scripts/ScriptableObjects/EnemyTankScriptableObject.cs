
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTankScriptableObject", menuName = "ScriptableObject/NewEnemyTank")]
public class EnemyTankScriptableObject : ScriptableObject
{
    public EnemyTankType TankType;
    public string TankName;
    public float Health;
    public float MovementSpeed;
    public float RotationSpeed;
    public float ChaseRadius;
    public float FighthRadius;
    public float BulletPower;
}


[CreateAssetMenu(fileName = "EnemyTankScriptableObjecList", menuName = "ScriptableObject/NewEnemyTankList")]
public class EnemyTankScriptableObjectList : ScriptableObject
{
    public List<EnemyTankScriptableObject> EnemyTankScriptableObjects;
}
public enum EnemyTankType
{
    Null,
    Speed,
    Power
}
