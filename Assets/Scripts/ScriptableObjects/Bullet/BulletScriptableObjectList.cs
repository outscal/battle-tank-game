using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is used to Create a Scriptable Object to hold all the Bullet Scriptable Objects in a List.
/// </summary>

namespace BulletScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObject/Bullet/BulletScriptableObjectList")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bulletScriptableObjectList;
    }
}
