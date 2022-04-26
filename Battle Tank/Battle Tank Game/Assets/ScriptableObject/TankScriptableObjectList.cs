using System;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObjects")  ]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}

