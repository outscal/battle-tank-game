using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObject/NewBulletList")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bullets;
}