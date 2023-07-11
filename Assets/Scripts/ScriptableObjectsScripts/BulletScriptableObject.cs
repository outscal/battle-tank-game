using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public int damage;
    public int range;

    public BulletView bulletView;
}