using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank
{

    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletScriptableObject")]

    public class BulletScriptableObject : ScriptableObject
    {
        public BulletType BulletType;
        public int Speed;
        public int Damage;
        public BulletView BulletView;
    }

    [CreateAssetMenu(fileName = "bulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletListScriptableObject")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bullets;
    }
}