using Bullet;
using UnityEngine;

namespace Attack
{
    public class TrackingAttack: Attack
    {
        private TankView _target;
        public TankView Target => _target;
        public TrackingAttack(BulletType type, Vector3 position, float damage, TankView target) : base(type, position, damage)
        {
            _target = target;
        }
    }
}