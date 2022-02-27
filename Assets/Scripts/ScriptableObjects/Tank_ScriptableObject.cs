using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank_ScriptableObject", menuName = "Tank/NewTank")]
public class Tank_ScriptableObject : ScriptableObject
{
    public Tank.Tank_Types TankType;
    public string TankName;
    public int Speed;
    public float Health;
    public float RotationSpeed;
}