using System;
using UnityEngine;

namespace Tank.States
{
    public class IdleState:State
    {
        private float _idleTime;
        private bool _isInitialized;
        
        public float IdleTime => _idleTime;

        private void OnEnable()
        {
            _isInitialized = false;
            _tankView.NavMeshAgent.speed = 0;
        }

        public void Init(float idleTime)
        {
            Debug.Log("Idle start! "+ idleTime);
            _idleTime = idleTime;
            _isInitialized = true;
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
    }
}