using Bullet;
using UnityEngine;

namespace Attack
{
    public class LinearAttack: Attack
    {
        private Vector3 _direction;
        public Vector3 Direction => _direction;
        public LinearAttack(BulletType type, Vector3 position, float damage,Vector3 direction) :base(type, position, damage)
        {
            _direction = direction;
        }
    }
}