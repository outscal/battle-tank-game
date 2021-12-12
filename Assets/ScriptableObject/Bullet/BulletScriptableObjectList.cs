using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObject/Bullet/CreateBulletList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bullets;
}
