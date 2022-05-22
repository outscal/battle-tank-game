using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Creates a scriptable object that holds a list of all the Tank Scriptable Objects Created.
/// </summary>
[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankSOList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] TankSOList;
}