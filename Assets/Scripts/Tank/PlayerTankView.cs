using System;
using UnityEngine;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : TankView
    {
        private Rigidbody _rigidbody;
        private InputSystem.InputSystem _inputSystem;

        public Rigidbody Rigidbody => _rigidbody;
        public InputSystem.InputSystem InputSystem => _inputSystem;

        public void SetInputSystem(InputSystem.InputSystem inputSystem) => _inputSystem = inputSystem;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _tankController.HandleAttacks();
        }

        private void FixedUpdate()
        {
            _tankController.Move();
        }

        protected override void OnCollisionEnter(Collision other)
        {
            base.OnCollisionEnter(other);
            if (other.gameObject.GetComponent<TankView>())
            {
                _tankController.TakeDamage(other.gameObject.GetComponent<TankView>().TankController.TankModel.Damage);
            }
        }
    }
}