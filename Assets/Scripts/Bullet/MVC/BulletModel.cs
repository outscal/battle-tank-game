
using UnityEngine;

public class BulletModel
{
    public float speed { get; private set; }
    public float power { get; private set; }


    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        speed = bulletScriptableObject.speed;
        power = bulletScriptableObject.power;
    }
}
