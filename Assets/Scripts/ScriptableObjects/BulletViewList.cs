using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Used to Create a Scriptable Object which holds all the Bullet Views in a List.
/// </summary>

[CreateAssetMenu(fileName = "BulletViewList", menuName = "ScriptableObjects/NewBulletViewList")]
public class BulletViewList : ScriptableObject
{
    public List<BulletView> bulletViewList;
}
