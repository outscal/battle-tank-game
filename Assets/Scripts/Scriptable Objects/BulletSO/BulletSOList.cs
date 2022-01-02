using UnityEngine;

namespace BulletSO
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/BulletScriptableObjectList")]
    public class BulletSOList : ScriptableObject
    {
        public BulletScriptableObject[] bulletList;
    }
}