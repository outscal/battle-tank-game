using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType type;
    public int speed;
    public int duration;
    public int damage;
    public BulletView bulletView;
}
[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObject/Bullet/BulletList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bulletObjects;
}
