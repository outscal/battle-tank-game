using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class for creating Tank Scriptable Objects with all the required properties.
/// </summary>

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float speed;
    public int health;
    public float rotationSpeed;
}
