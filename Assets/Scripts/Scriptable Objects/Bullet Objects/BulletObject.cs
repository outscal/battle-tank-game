using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Object", menuName = "Objects/New Tank Object")]
public class BulletObject : ScriptableObject
{
   public BulletView bulletView;
   public BulletType bulletType;
   public float Speed;
   public int Damage;
}
