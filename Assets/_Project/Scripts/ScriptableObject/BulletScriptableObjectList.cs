using UnityEngine;

namespace BattleTank
{
    [CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/BulletList")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bullets;
    }
}