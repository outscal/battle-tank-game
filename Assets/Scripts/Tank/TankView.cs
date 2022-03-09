using UnityEngine;

namespace Tank
{
    public abstract class TankView : MonoBehaviour, Interfaces.IDamageable
    {
        #region Serialize Data members

        [SerializeField] private Transform _shootingPoint;

        #endregion

        #region Protected Data members

        protected TankController _tankController;

        #endregion

        #region Setters

        public void SetTankController(TankController tankController) => _tankController = tankController;

        #endregion

        #region Getters

        public TankController TankController => _tankController;
        public Transform ShootingPoint => _shootingPoint;

        #endregion

        #region Public Functions

        public void DamageReceived(float amount)
        {
            _tankController.TakeDamage(amount);
        }

        #endregion
    }
}
