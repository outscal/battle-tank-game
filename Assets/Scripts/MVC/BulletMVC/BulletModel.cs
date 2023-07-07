using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel : MonoBehaviour
{
    private BulletScriptableObject bulletSO;
    public GameObject Partical { get; }
    public float Speed { get; }
    public float Damage { get; }

    private float lifetime;
    public BulletModel(BulletScriptableObject _bulletSO)
    {
        Speed = bulletSO.Speed;
        Damage = bulletSO.Damage;
        lifetime = bulletSO.Lifetime;
        shostOfBullet = bulletSO.ShotsFired;
        Partical = bulletSO.ParticalEffect;

    }
    private BulletController bulletController1;
    private int shostOfBullet;

  

    public void SetBulletController(BulletController bulletController)
    {
        bulletController1 = bulletController;
    }
}
