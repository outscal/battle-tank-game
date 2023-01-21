using UnityEngine;
using UnityEngine.UIElements;

public class BulletModel
{
    public BulletType bulletType;
    public float  bulletSpeed { get; set; }
    public float bulletDamage;

    public BulletController bulletController { get; set;}

    



    public BulletModel(BulletScriptableObject _bulletScriptableObject)
    {
        bulletType = _bulletScriptableObject.bulletType;
        bulletSpeed = _bulletScriptableObject.speed;
        bulletDamage = _bulletScriptableObject.damage;
        
        
    }

    public void SetBulletController(BulletController _bulletController)
    {
        bulletController =_bulletController;
    }
}
