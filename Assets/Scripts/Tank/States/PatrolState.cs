using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank.States
{
    public class PatrolState : State
    {
        [SerializeField] private float mapRange;
        private float _refreshTime;
        public float RefreshTime => _refreshTime;

        private bool _isInitialized;
        private float _counter;
        private void OnEnable()
        {
            _isInitialized = false;
        }

        public void Init(float refreshTime)
        {
            //_tankView.NavMeshAgent.enabled = true;
            _tankView.NavMeshAgent.SetDestination(GetRandomPosition());
            _refreshTime = refreshTime;
            _counter = _refreshTime;
            _isInitialized = true;
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

        private Vector3 GetRandomPosition()
        {
            return new(GetRandomValue(), 1, GetRandomValue());
        }

        private float GetRandomValue()
        {
            return Random.Range(-mapRange, mapRange);
        }

        private void OnDisable()
        {
           // _tankView.NavMeshAgent.enabled = false;
        }
    }
}