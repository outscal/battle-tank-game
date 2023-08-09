using UnityEngine;

public class AmmoScriptableObject : ScriptableObject
{
    [SerializeField]
    float speed = 1f, damage = 1, maxCollisions = 1f, lifeTime = 1f, bounciness = 1f;
    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }
    public float MaxCollisions { get { return maxCollisions; } }
    public float LifeTime { get { return lifeTime; } }
    public float Bounciness { get { return bounciness; } }

    [SerializeField]
    bool useGravity = false;
    public bool UseGravity { get { return useGravity; } }

    [SerializeField]
    string ammoName;
    public string BulletName { get { return ammoName; } }

    [SerializeField]
    protected AmmoType ammoType;
    public AmmoType AmmoType { get { return ammoType; } }
}
