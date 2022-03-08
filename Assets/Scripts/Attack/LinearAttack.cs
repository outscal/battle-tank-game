using Tank;
using UnityEngine;

namespace Attack
{
    public class LinearAttack: Attack
    {
        #region Private data members

        private Vector3 _direction;

        #endregion

        #region Public data members

        public Vector3 Direction => _direction;

        #endregion

        #region Constructors

        public LinearAttack(Scriptable_Object.Bullet.Bullet bullet, Vector3 position, float damage,Vector3 direction,TankType tankType) :base(bullet, position, damage,tankType)
        {
            _direction = direction;
        }

        #endregion
    }
}