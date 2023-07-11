using UnityEngine;
using BattleTank.Bullet;

namespace BattleTank.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBullet")]
    public class BulletScriptableObject : ScriptableObject
    {
        public int damage;
        public int range;

        public BulletView bulletView;
    }
}
