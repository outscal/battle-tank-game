using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/EnemyTank")]
public class EnemyScriptableObject : ScriptableObject
{
    public TankType TankType;
    public string TankName;
    public float Speed;
    public float Health;

    public static explicit operator int(EnemyScriptableObject v)
    {
        throw new NotImplementedException();
    }
}
