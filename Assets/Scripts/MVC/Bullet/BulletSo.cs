using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
public class BulletSo : ScriptableObject
{
    public int roundsPerMinute;
    public int damage;
    public int range;
    public BulletVi bulletView;
}
