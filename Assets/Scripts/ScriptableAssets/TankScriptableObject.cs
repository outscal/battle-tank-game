using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
