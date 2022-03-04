using Bullet;
using Tank;
using UnityEngine;

namespace Attack
{
    public class TrackingAttack: Attack
    {
        private TankView _target;
        public TankView Target => _target;
        public TrackingAttack(Scriptable_Object.Bullet.Bullet bullet, Vector3 position, float damage, TankView target, TankType tankType) : base(bullet, position, damage, tankType)
        {
            _target = target;
        }
    }
}