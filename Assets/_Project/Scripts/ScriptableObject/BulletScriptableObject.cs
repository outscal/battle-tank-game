using BattleTank.Enum;
using UnityEngine;

namespace BattleTank.BulletSO
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public BulletType BulletType;
        public float Damage;
        public float Speed;
    }
}