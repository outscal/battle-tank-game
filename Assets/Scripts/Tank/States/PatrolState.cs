using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank.States
{
    public class PatrolState : State
    {
        #region Serialized Data members

        [SerializeField] private float mapRange;

        #endregion

        #region Private Data members

        private float _refreshTime;
        private bool _isInitialized;
        private float _counter;

        #endregion

        #region Getters

        public float RefreshTime => _refreshTime;

        #endregion

        #region Unity Functions

        private void OnEnable()
        {
            _isInitialized = false;
        }

        private void Update()
        {
            if (!_isInitialized) return;
            if (_counter >= 0)
            {
                _counter -= Time.deltaTime;
                return;
            }

            _tankView.NavMeshAgent.SetDestination(GetRandomPosition());
            _counter = _refreshTime;
        }

        #endregion

        #region Public Functions

        public void Init(float refreshTime)
        {
            _tankView.NavMeshAgent.SetDestination(GetRandomPosition());
            _refreshTime = refreshTime;
            _counter = _refreshTime;
            _isInitialized = true;
        }

        #endregion

        #region Private Data members

        private Vector3 GetRandomPosition()
        {
            return new(GetRandomValue(), 1, GetRandomValue());
        }

        private float GetRandomValue()
        {
            return Random.Range(-mapRange, mapRange);
        }

        #endregion
    }
}