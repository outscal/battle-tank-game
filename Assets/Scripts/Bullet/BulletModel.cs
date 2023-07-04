
using UnityEngine;

public class BulletModel
{
    public float speed { get; private set; }
    public float power { get; private set; }

    public PlayerTankView tankView { get; private set; }

    public BulletModel(BulletScriptableObject bulletScriptableObject,PlayerTankView tankView)
    {
        speed = bulletScriptableObject.speed;
        power = bulletScriptableObject.power;
        this.tankView = tankView;
    }
}
