using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank
{

    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletScriptableObject")]

    public class BulletScriptableObject : ScriptableObject
    {
        public BulletView BulletView;
        public BulletType bulletType;
        public float bulletForce;
        public float bulletDamage;       
    }

    [CreateAssetMenu(fileName = "bulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletListScriptableObject")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bullets;
    }
}