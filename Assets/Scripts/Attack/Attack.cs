using Bullet;
using UnityEngine;

namespace Attack
{
    public abstract class Attack
    {
        private float _damage;
        private BulletType _bulletType;
        private Vector3 _position;

        public float Damage => _damage;
        public BulletType BulletType => _bulletType;
        public Vector3 Position => _position;

        public Attack(BulletType type, Vector3 position, float damage)
        {
            _damage = damage;
            _bulletType = type;
            _position = position;
        }
    }
}