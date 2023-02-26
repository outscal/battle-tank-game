using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private InputReader input;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private float _jumpForce;

    private TankController tankController;

    private Vector2 _moveDirection;
    private bool _isJumping;

    private void Start()
    {
        StartGame();

    }

    public void StartGame()
    {
        CreateNewTank();
        SubscribeInputEvents();
    }

    private void SubscribeInputEvents()
    {
        input.MoveEvent += HandleMove;
        input.JumpEvent += HandleJump;
        input.JumpCancelledEvent += HandleCancelledJump;
    }

    public void CreateNewTank()
    {
        TankModel model = new TankModel(_speed, _rotateSpeed, _jumpForce);
        tankController = new TankController(model, tankView);
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        tankController.Move(_moveDirection);
    }

    private void Jump()
    {
        tankController.Jump(_isJumping);
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
