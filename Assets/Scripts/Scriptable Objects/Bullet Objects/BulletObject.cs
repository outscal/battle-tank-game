using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Object", menuName = "Objects/New Bullet Object")]
public class BulletObject : ScriptableObject
{
   public BulletView bulletView;
   public BulletType bulletType;
   public float Speed;
   public int Damage;
   public float ExplosionRadius;
   public float ExplosionForce;
}
