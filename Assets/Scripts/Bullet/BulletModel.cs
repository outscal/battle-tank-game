using UnityEngine;

public class BulletModel
{
    public BulletType BulletType { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
       // BulletType = bulletScriptableObject.bulletType;
        //Damage = bulletScriptableObject.damage;
        //Speed = bulletScriptableObject.speed;

    }
}