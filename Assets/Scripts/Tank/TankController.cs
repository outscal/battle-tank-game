using UnityEngine;

namespace Tank
{
    public abstract class TankController 
    {
        #region Public Properties

        public TankModel TankModel { get; protected set; }
        public TankView TankView { get; }

        #endregion

        #region Constructors

        protected TankController(TankView tankView)
        {
            TankView = GameObject.Instantiate(tankView);
            TankView.SetTankController(this);
        }

        #endregion

        #region Protected Functions

        protected abstract void DestroyMe();

        #endregion

        #region Public Functions

        public virtual void TakeDamage(float amount) => TankModel.DecreaseHealth(amount);

        #endregion
    }
}
