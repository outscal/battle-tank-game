using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Object", menuName = "Objects/New Tank Object")]
public class TankObject : ScriptableObject
{
    [Header("Type")]
    public TypeDamagable Type;
    public TankView tankView;
    public TankType tankType;
    [Header("Speed")]
    public float Speed;
    public float TurnSpeed;
    [Header("Hitpoints")]
    public int Health;
    [Header("Power")]
    public int Damage;
    [Header("Material")]
    public Material color;
}
