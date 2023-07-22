using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class BulletModel
    {
        private BulletScriptableObject bulletSO;
        public GameObject Partical { get; }

        public int Speed { get; }
        public int Damage { get; }

        public int lifetime;

        private BulletController bulletController1;
        public int shostOfBullet;
        public BulletModel(BulletScriptableObject _bulletSO)
        {
            bulletSO = _bulletSO;
            Speed = _bulletSO.Speed;
            Damage = _bulletSO.Damage;
            lifetime = _bulletSO.Lifetime;
            shostOfBullet = _bulletSO.ShotsFired;
            Partical = _bulletSO.ParticalEffect;
        }




        public void SetBulletController(BulletController bulletController)
        {
            bulletController1 = bulletController;
        }
    }
}