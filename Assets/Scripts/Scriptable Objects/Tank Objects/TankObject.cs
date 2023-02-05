using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Object", menuName = "Objects/New Tank Object")]
public class TankObject : ScriptableObject
{
   public TankView tankView;
   public TankType tankType;
   [Header("Speed")]
   public float moveSpeed;
   public float TurnSpeed;
   [Header("Hitpoints")]
   public int Health;
   [Header("Power")]
   public int Damage;
   [Header("Material")]
    public Material color;
}
