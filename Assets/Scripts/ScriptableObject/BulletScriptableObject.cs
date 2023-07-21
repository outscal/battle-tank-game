using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = " ScriptableObject/NewBulletSo",order = 4)]
public class BulletScriptableObject : ScriptableObject
{

    [SerializeField] private int speed;
    [SerializeField] private int damage;
    [SerializeField] private int  lifetime;
    [SerializeField] private int shotsFired;
    [SerializeField] private GameObject particaleffect;

    public int Speed { get => speed; set => speed = value; }
    public int Damage { get => damage; set => damage = value; }
    public int  Lifetime { get => lifetime; set => lifetime = value; }

    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float lifetime;
    [SerializeField] private int shotsFired;
    [SerializeField] private GameObject particaleffect;

    public float Speed { get => speed; set => speed = value; }
    public float Damage { get => damage; set => damage = value; }
    public float Lifetime { get => lifetime; set => damage = value; }

    public int ShotsFired { get => shotsFired; set => shotsFired = value; }
    public GameObject ParticalEffect { get => particaleffect; set => particaleffect = value; }
}


