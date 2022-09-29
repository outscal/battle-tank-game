using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoBehaviour
{
    BulletController bulletController;
    [Header("Bullet Scriptable Object List")]
    [SerializeField] List<BulletScriptableObject> bulletList;
    [Header("Bullet Models with BulletView List")]
    [SerializeField] List<BulletView> bulletViewList;
    //[serializefield] list<bullet>
    public void InstantiateBullet(int spawnIndex)
    {
        BulletModel bulletModel= new BulletModel(bulletList[spawnIndex].bulletSpeed, 
            bulletList[spawnIndex].bulletDamage) ;
        bulletController = new BulletController(bulletViewList[spawnIndex], bulletModel) ;
    }
}
