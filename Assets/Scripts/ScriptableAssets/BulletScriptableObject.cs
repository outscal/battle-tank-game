using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/BulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{

    public BulletType BulletType;
    public int bulletSpeed;

}

