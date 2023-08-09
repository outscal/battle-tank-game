using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/Ammo/Bullet")]
public class BulletScriptableObject : AmmoScriptableObject
{
    [SerializeField]
    BulletView bulletViewPrefab;
    public BulletView BulletViewPrefab { get { return bulletViewPrefab; } }
}
