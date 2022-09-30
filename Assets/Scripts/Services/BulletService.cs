using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : MonoBehaviour
{
    GameObjectType gameObjectType;
    BulletController bulletController;
    [Header("Bullet Scriptable Object List")]
    [SerializeField] List<BulletScriptableObject> bulletSpecsList;
    [Header("Bullet Models with BulletView List")]
    [SerializeField] List<BulletView> bulletViewList;
    //[serializefield] list<bullet>
    public void InstantiateBullet(int spawnIndex)
    {
        gameObjectType = GameObjectType.Bullet;
        BulletModel bulletModel= new BulletModel(bulletSpecsList[spawnIndex].bulletSpeed, 
            bulletSpecsList[spawnIndex].bulletDamage, this.transform) ;
        bulletController = new BulletController(bulletViewList[spawnIndex], bulletModel) ;
    }
}
