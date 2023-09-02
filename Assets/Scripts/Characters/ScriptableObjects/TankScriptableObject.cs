using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObject/Tank/NewTank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType TankType;
    public float speed;
    public float health;
    public float Damage;
    public float rotationspeed;
    public string tankName;
    public TankView tankView;
    public Vector3 tankTransform;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/Tank/TankList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tankObjects;
}
