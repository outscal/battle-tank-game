using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BulletScriptableObject", menuName ="ScriptableObject/Bullet")]
public class BulletScriptableObject : ScriptableObject
{
    [Header("Bullet Prefab")]
    public Assets.Scripts.MVC.Tank.BulletView bulletView;
    [Header("Bullet Type")]
    public Assets.Scripts.MVC.Tank.BulletType bulletType;
    [Header("Shooting Parameters")]
    public int damage;
    public float explosionRadius;
    public float explosionForce;
    [Header("Time Parameter")]
    public float maxLifeTime;
}
