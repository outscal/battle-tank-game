using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/Bullet")]
public class BulletScriptableObject : ScriptableObject
{
    [SerializeField]
    float speed = 1f, damage = 1;
    public float Speed { get { return speed; } }
    public float Damage { get { return damage; } }

    [SerializeField]
    BulletType bulletType;
    public BulletType BulletType { get { return bulletType; } }

    [SerializeField]
    string bulletName;
    public string BulletName { get { return bulletName; } }

    [SerializeField]
    BulletView bulletViewPrefab;
    public BulletView BulletViewPrefab { get { return bulletViewPrefab; } }
}
