
using UnityEngine;

public class BulletModel
{
    public float Speed { get; private set; }
    public int Power { get; private set; }


    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        Speed = bulletScriptableObject.speed;
        Power = bulletScriptableObject.power;
    }
}
