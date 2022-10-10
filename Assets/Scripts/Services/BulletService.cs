using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ObjectPool;

namespace TankServices
{
    public class BulletService : MonoBehaviour
    {
        int bulletFireCount = 0;
        BulletController bulletController;
        [Header("Bullet Scriptable Object List")]
        [SerializeField] List<BulletScriptableObject> bulletSpecsList;
        [Header("Bullet Models with BulletView List")]
        [SerializeField] List<BulletView> bulletViewList;
        [SerializeField] ParticleSystem shellExplosion;
        int bulletNum=0;
        //[serializefield] list<bullet>
        public void InstantiateBullet(int spawnIndex)
        {
            ServiceEvents.Instance.OnShoot?.Invoke(++bulletFireCount) ;
            if(bulletNum < GenericPoolScript<BulletController>.Instance.GetCount())
            {
                BulletModel bulletModel = new BulletModel(bulletSpecsList[spawnIndex].bulletSpeed,
                bulletSpecsList[spawnIndex].bulletDamage, this.transform, shellExplosion);
                bulletController = new BulletController(bulletViewList[spawnIndex], bulletModel);
                bulletNum++;
            }
            if (bulletNum >= GenericPoolScript < BulletController>.Instance.GetCount())
            {
                bulletController = GenericPoolScript<BulletController>.Instance.Dequeue();
                bulletController.ChangeSpawnLocation(this.transform);
                //bulletController.SetObjectActive();
            }
        }
    }
}