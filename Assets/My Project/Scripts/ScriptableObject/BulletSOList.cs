using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Datalist", menuName = " ScriptableObject/NewBulletSolist", order = 4)]
public class BulletSOList : ScriptableObject
{
    public List<BulletScriptableObject> bulletList = new List<BulletScriptableObject>();
}