using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType TankType;
    public string TankName;
    public float Speed;
    public float Health;
    public float RotationRate;
    public float TurretRotationRate;
    public BulletType bulletType;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}