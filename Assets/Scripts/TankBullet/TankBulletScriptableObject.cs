using System;
using UnityEngine;


[CreateAssetMenu(fileName = "TankBulletScriptableObject", menuName = "TankBulletScriptableObject/TankBullet")]
public class TankBulletScriptableObject : ScriptableObject
{
    public TankBUlletType TankBUlletType;
    public string TankBulletName;
 // public Transform BulletSpawnPosition;
    public GameObject BulletPrefab;
    public float BulletSpeed;

}

