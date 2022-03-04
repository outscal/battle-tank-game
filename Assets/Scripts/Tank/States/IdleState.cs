using UnityEngine;

namespace Tank.States
{
    public class IdleState:State
    {
        #region Private Data members

        private float _idleTime;
        private bool _isInitialized;

        #endregion

        #region Getters

        public float IdleTime => _idleTime;

        #endregion

        #region Unity Functions

        private void OnEnable()
        {
            _isInitialized = false;
            _tankView.NavMeshAgent.speed = 0;
        }

        private void Update()
        {
            if(!_isInitialized) return;
            if (_idleTime >= 0)
            {
                _idleTime -= Time.deltaTime;
                return;
            }
            _tankView.TimeToMove();
        }

        private void OnDisable()
        {
            _tankView.NavMeshAgent.speed = _tankView.TankController.TankModel.Speed;
        }

        #endregion

        #region Public Functions

        public void Init(float idleTime)
        {
            Debug.Log("Idle start! "+ idleTime);
            _idleTime = idleTime;
            _isInitialized = true;
        }

        #endregion
    }
}