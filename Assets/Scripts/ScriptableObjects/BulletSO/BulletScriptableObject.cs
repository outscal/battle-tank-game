using System;
using UnityEngine;
using BulletServices;

namespace BulletSO
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/NewBulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        [Header("MVC Essentials")]
        public BulletView bulletView;

        [Header("Movement and Type")]
        public float speed;
        public float damage;
        public BulletType bulletType;

    }
    [CreateAssetMenu(fileName = "   ", menuName = "ScriptableObject/Bullet/NewBulletScriptableObjectList")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bulletsTypes;
    }
}