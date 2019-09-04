using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Bullet;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/BulletScriptableObject", order = 1)]

public class BulletScriptableObject : ScriptableObject
{
    public int damage;
    public BulletView bulletPrefab;
}
