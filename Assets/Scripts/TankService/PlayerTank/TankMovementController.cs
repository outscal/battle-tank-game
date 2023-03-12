using UnityEngine;

namespace TankBattle.Tank.PlayerTank
{
    public class TankMovementController : MonoBehaviour
    {
        [SerializeField] private InputSystem.InputReader input;
        private TankController tankController;

        private Vector2 _moveDirection;
        private bool _isJumping;

        private void Start()
        {
            tankController = PlayerService.Instance.GetTankController();
            SubscribeInputEvents();
        }

        private void OnDisable()
        {
            UnsubscribeInputEvents();
        }

        private void SubscribeInputEvents()
        {
            input.MoveEvent += HandleMove;
            input.JumpEvent += HandleJump;
            input.JumpCancelledEvent += HandleCancelledJump;
        }

        private void UnsubscribeInputEvents()
        {
            input.MoveEvent -= HandleMove;
            input.JumpEvent -= HandleJump;
            input.JumpCancelledEvent -= HandleCancelledJump;
        }
        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            if (_moveDirection != Vector2.zero)
            {
                tankController.MoveRotate(_moveDirection);
            }
        }

        private void Jump()
        {
            if (_isJumping)
            {
                tankController.Jump();
            }
        }

        private void HandleCancelledJump()
        {
            _isJumping = false;
        }

        private void HandleJump()
        {
            _isJumping = true;
        }

        private void HandleMove(Vector2 dir)
        {
            _moveDirection = dir;
        }
    }
}