using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletScriptableObject", menuName = "ScriptableObject/Bullet/New Bullet ScriptableObject")]
public class BulletSO : ScriptableObject
{
    public BulletTypes BulletType;
    public string BulletName;
    public float Speed;
}