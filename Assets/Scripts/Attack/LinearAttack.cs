using Bullet;
using Tank;
using UnityEngine;

namespace Attack
{
    public class LinearAttack: Attack
    {
        private Vector3 _direction;
        public Vector3 Direction => _direction;
        public LinearAttack(Scriptable_Object.Bullet.Bullet bullet, Vector3 position, float damage,Vector3 direction,TankType tankType) :base(bullet, position, damage,tankType)
        {
            _direction = direction;
        }
    }
}