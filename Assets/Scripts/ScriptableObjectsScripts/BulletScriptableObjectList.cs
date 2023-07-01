using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletObjectList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bullets;
}
[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public int roundsPerMinute;
    public int damage;
    public int range;
    public BulletView bulletView;
}
