using System.Collections.Generic;
using TankScriptableObjects;
using UnityEngine;

/// <summary>
/// This Creates a scriptable object that holds a list of all the Tank Scriptable Objects Created.
/// </summary>

namespace TankSOList
{
    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/Tank/TankScriptableObjectList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tankScriptableObject;
    }
}
