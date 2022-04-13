using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType BulletType;
    public int BulletDamage;
    public int BulletSpeed;
    public float MaxLifeTime;
    public float ExplosionRadius;
}
