
using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/NewBullet")]
public class BulletScriptableObject : ScriptableObject
{
    public float speed;
    public float power;
}

[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObject/NewBulletList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bullets;
}