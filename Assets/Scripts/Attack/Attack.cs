using UnityEngine;

namespace Attack
{
    public abstract class Attack
    {
        #region Private data members

        private float _damage;
        private Scriptable_Object.Bullet.Bullet _bullet;
        private Vector3 _position;
        private Tank.TankType _tankType;

        #endregion

        #region Public data members

        public Tank.TankType TankType => _tankType;
        public float Damage => _damage;
        public Scriptable_Object.Bullet.Bullet Bullet => _bullet;
        public Vector3 Position => _position;

        #endregion

        #region Constructors

        protected Attack(Scriptable_Object.Bullet.Bullet bullet, Vector3 position, float damage, Tank.TankType tankType)
        {
            _damage = damage;
            _bullet = bullet;
            _position = position;
            _tankType = tankType;
        }

        #endregion
    }
}