using UnityEngine;

public class TankScriptableObject : ScriptableObject
{
    [SerializeField]
    float speed = 1f, health = 100f, fireRate = 1, damage = 1;
    public float Speed { get { return speed; } }
    public float Health { get { return health; } }
    public float FireRate { get { return fireRate; } }
    public float Damage { get { return damage; } }

    [SerializeField]
    TankType tankType;
    public TankType TankType { get { return tankType; } }

    [SerializeField]
    string tankName;
    public string TankName { get { return tankName; } }

    [SerializeField]
    BulletScriptableObject bulletScriptableObject;
    public BulletScriptableObject BulletScriptableObject { get { return bulletScriptableObject; } }

    protected TankCategory tankCategory;
    public TankCategory TankCategory { get { return tankCategory; } }

}
