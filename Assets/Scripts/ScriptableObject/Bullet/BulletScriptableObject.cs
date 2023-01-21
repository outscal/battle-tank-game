using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/ScriptableBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType bulletType;
    public float speed;
    public float damage;
    public GameObject prefab;
    public GameObject BulletParticleEffect;


}
