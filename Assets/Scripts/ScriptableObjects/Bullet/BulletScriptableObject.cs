using UnityEngine;
using BulletServices;

/// <summary>
/// This Class is used to create Bullet Scriptable Objects with all the required properties of Bullets.
/// </summary>

namespace BulletScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObject/Bullet/BulletScriptableObject")]
    public class BulletScriptableObject : ScriptableObject
    {
        [Header("Bullet Prefab")]
        public BulletView bulletView;

        [Header("Bullet Type")]
        public BulletType bulletType;

        [Header("Shooting Parameters")]
        public int damage;

        [Header("Time Parameters")]
        public float maxLifeTime;
    }
}