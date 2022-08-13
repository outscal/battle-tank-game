using UnityEngine;

/// <summary>
/// This Function stores & is used to reference the data about a Bullet entity.
/// </summary>
public class BulletModel
{
    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        BulletType = bulletScriptableObject.bulletType;
        Damage = bulletScriptableObject.Damage;
        Speed = bulletScriptableObject.speed;
    }

    public BulletType BulletType { get; }
    public int Damage { get; }
    public float Speed { get; }
}
