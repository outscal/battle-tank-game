public class BulletModel
{
    public float Speed { get; protected set; }
    public float Damage { get; protected set; }

    public BulletType Type { get; protected set; }

    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        Speed = bulletScriptableObject.Speed;
        Damage = bulletScriptableObject.Damage;
        Type = bulletScriptableObject.BulletType;
    }

    public BulletModel(float speed, float damage, BulletType bulletType)
    {
        Speed = speed;
        Damage = damage;
        Type = bulletType;
    }
}