using UnityEngine;

namespace BulletScriptables
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/BulletScriptableObjectList")]
    public class BulletSOList : ScriptableObject
    {
        public BulletScriptableObject[] bulletTypes;
    }
}

