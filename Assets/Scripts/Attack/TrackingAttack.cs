using Tank;
using UnityEngine;

namespace Attack
{
    public class TrackingAttack: Attack
    {
        #region Private data members

        private TankView _target;

        #endregion

        #region Public data members

        public TankView Target => _target;

        #endregion

        #region Constructors

        public TrackingAttack(Scriptable_Object.Bullet.Bullet bullet, Vector3 position, float damage, TankView target, Tank.TankType tankType) : base(bullet, position, damage, tankType)
        {
            _target = target;
        }

        #endregion
    }
}