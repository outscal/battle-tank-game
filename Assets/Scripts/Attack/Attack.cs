using Bullet;
using Tank;
using UnityEngine;

namespace Attack
{
    public abstract class Attack
    {
        private float _damage;
        private Scriptable_Object.Bullet.Bullet _bullet;
        private Vector3 _position;
        private TankType _tankType;

        public TankType TankType => _tankType;
        public float Damage => _damage;
        public Scriptable_Object.Bullet.Bullet Bullet => _bullet;
        public Vector3 Position => _position;

        public Attack(Scriptable_Object.Bullet.Bullet bullet, Vector3 position, float damage, TankType tankType)
        {
            _damage = damage;
            _bullet = bullet;
            _position = position;
            _tankType = tankType;
        }
    }
}