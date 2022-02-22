using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank", menuName = "Tank")]
public class TankScriptableObj : ScriptableObject
{
    public int Speed;
    public float Health;
    public TankTypes TankType;
    public string Name;
}



