using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Bullet.View;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName ="BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletType bulletType;
        public float speed;
        public float damage;
        public BulletView BulletView;
    }

    [CreateAssetMenu(fileName ="BulletScriptableObjectList", menuName ="ScriptableObjects/NewBulletListScriptableObject")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bullet;
    }
}