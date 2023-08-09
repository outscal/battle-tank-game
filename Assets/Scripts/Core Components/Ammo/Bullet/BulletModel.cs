public class BulletModel
{
    public float Speed { get; protected set; }
    public float Damage { get; protected set; }
    public float MaxCollisions { get; protected set; }
    public float LifeTime { get; protected set; }
    public float Bounciness { get; protected set; }

    public bool UseGravity { get; protected set; }

    public BulletModel(BulletScriptableObject bulletScriptableObject)
    {
        Speed = bulletScriptableObject.Speed;
        Damage = bulletScriptableObject.Damage;
        MaxCollisions = bulletScriptableObject.MaxCollisions;
        LifeTime = bulletScriptableObject.LifeTime;
        Bounciness = bulletScriptableObject.Bounciness;

        UseGravity = bulletScriptableObject.UseGravity;
    }
}