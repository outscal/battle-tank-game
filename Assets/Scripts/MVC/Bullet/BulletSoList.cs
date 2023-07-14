using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletObjectList")]
public class BulletSoList : ScriptableObject
{
    public BulletSo[] bullets;
}
