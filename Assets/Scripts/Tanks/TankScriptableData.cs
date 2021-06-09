using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTank", menuName ="Tank")]
public class TankScriptableData : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float tankSpeed;
    public float tankHealth;
    public float tankDamage;
}
