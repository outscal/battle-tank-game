using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "SciptableObjects/NewTankListScriptableObject")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}