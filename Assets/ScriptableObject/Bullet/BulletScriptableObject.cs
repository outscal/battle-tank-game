using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public float speed;
    public float damage;
}
