using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletListScriptableObject", menuName = "ScriptableObject/Bullet/New BulletList ScriptableObject")]
public class BulletListSO : ScriptableObject
{
    public BulletSO[] bullets;
}