using UnityEngine;

namespace Tank.States
{
    public abstract class State : MonoBehaviour
    {
        #region Protected Data members

        protected EnemyTankView _tankView;

        #endregion

        #region Unity Functions

        protected void Awake()
        {
            _tankView = GetComponent<EnemyTankView>();
        }

        #endregion
        
        #region Public Functions

        public void Enter()
        {
            enabled = true;
        }

        public void Exit()
        {
            enabled = false;
        }

        #endregion
    }
}