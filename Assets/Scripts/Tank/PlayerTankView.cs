using UnityEngine;

namespace Tank
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerTankView : TankView
    {
        #region Private Data Members

        private Rigidbody _rigidbody;
        private InputSystem.InputSystem _inputSystem;

        #endregion

        #region Getters

        public Rigidbody Rigidbody => _rigidbody;
        public InputSystem.InputSystem InputSystem => _inputSystem;
        public void SetInputSystem(InputSystem.InputSystem inputSystem) => _inputSystem = inputSystem;

        #endregion

        #region UnityFunctions

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            ((PlayerTankController)_tankController).HandleAttacks();
        }

        private void FixedUpdate()
        {
            ((PlayerTankController)_tankController).Move();
        }

        #endregion
    }
}