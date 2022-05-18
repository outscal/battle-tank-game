using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is used to Create a Scriptable Object to hold all the Bullet Scriptable Objects in a List.
/// </summary>
[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletSOList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public List<BulletScriptableObject> BulletSOList;
}

