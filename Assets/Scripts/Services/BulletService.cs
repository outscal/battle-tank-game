using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ObjectPool;

namespace TankServices
{
    public class BulletService : GenricSingleton<BulletService>
    {
        int bulletFireCount = 0;
        BulletController bulletController;
        [Header("Bullet Scriptable Object List")]
        [SerializeField] List<BulletScriptableObject> bulletSpecsList;
        [Header("Bullet Models with BulletView List")]
        [SerializeField] List<BulletView> bulletViewList;
        [Header("Number of Bullets for the Pool")]
        [SerializeField] int bulletPoolCount=20 ; 
        [SerializeField] ParticleSystem shellExplosion; 
        //[serializefield] list<bullet>
        public void InstantiateBullet(int spawnIndex)
        {
            ServiceEvents.Instance.OnShoot?.Invoke(++bulletFireCount);
            if (bulletFireCount < bulletPoolCount)
            {
                BulletModel bulletModel = new BulletModel(bulletSpecsList[spawnIndex].bulletSpeed,
                bulletSpecsList[spawnIndex].bulletDamage, this.transform, shellExplosion);
                bulletController = new BulletController(bulletViewList[spawnIndex], bulletModel);
            }
            else
            {
                bulletController = GenericPoolScript<BulletController>.Instance.Dequeue();
                bulletController.ChangeSpawnLocation(this.transform);
                //bulletController.SetObjectActive();
            }
        }
    }
}