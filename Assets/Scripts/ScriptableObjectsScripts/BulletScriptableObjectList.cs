using UnityEngine;

namespace BattleTank.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletObjectList")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bullets;
    }
}
