using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is used to Create a Scriptable Object which holds all the Bullet Views in a List.
/// </summary>
[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletViewList")]
public class BulletViewList : ScriptableObject
{
    public List<BulletView> bulletViewList;
}
