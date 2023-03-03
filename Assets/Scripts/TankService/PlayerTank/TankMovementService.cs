using UnityEngine;

namespace TankBattle.TankService.PlayerTank.MoveService
{
    public class TankMovementService : MonoBehaviour
    {
        [SerializeField] private InputReader input;
        private TankController tankController;

        private Vector2 _moveDirection;
        private bool _isJumping;

        public void SetController(TankController _tankController)
        {
            tankController = _tankController;
        }

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
                tankController.Move(_moveDirection);
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