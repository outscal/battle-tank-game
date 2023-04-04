using UnityEngine;

namespace BattleTank.BulletSO
{
    [CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/BulletList")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] Bullets;
    }
}