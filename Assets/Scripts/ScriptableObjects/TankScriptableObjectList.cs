using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Creates a scriptable object that holds a list of all the Tank Scriptable Objects Created.
/// </summary>

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankScriptableObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public List<TankScriptableObject> tankScriptableObjectList;
}
