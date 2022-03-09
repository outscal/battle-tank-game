using UnityEngine;

namespace Tank.States
{
    public class IdleState:State
    {
        #region Serialized Data members

        [SerializeField] private float _idleTime =5f;

        #endregion

        #region Private Data members

        private float _counter;

        #endregion

        #region Getters

        public float IdleTime => _idleTime;

        #endregion

        #region Unity Functions

        private void OnEnable()
        {
            _tankView.NavMeshAgent.speed = 0;
            _counter = _idleTime;
        }

        private void Update()
        {
            if (_counter >= 0)
            {
                _counter -= Time.deltaTime;
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
        

        #endregion
    }
}