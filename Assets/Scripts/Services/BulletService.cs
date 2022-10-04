using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoBehaviour
{
    BulletController bulletController;
    [Header("Bullet Scriptable Object List")]
    [SerializeField] List<BulletScriptableObject> bulletSpecsList;
    [Header("Bullet Models with BulletView List")]
    [SerializeField] List<BulletView> bulletViewList;
    [SerializeField] ParticleSystem shellExplosion;
    //[serializefield] list<bullet>
    public void InstantiateBullet(int spawnIndex)
    {
        BulletModel bulletModel= new BulletModel(bulletSpecsList[spawnIndex].bulletSpeed, 
            bulletSpecsList[spawnIndex].bulletDamage, this.transform, shellExplosion) ;
        bulletController = new BulletController(bulletViewList[spawnIndex], bulletModel) ;
    }
}
