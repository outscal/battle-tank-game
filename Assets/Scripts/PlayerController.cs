using System;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputReader input;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float degs = 360f;
    [SerializeField] private float jumpSpeed= 5f;

    private Vector2 _moveDirection;
    private bool _isJumping;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        input.MoveEvent += HandleMove;
        input.JumpEvent += HandleJump;
        input.JumpCancelledEvent += HandleCancelledJump;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
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

    private void Move()
    {
        if(_moveDirection == Vector2.zero)
        {
            return;
        }
        else
        {
        // perform move and turn function from one vector value
            Vector3 moveDirection = new Vector3(_moveDirection.x, 0, _moveDirection.y);

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            targetRotation = Quaternion.RotateTowards(
                transform.rotation,
            targetRotation,
                degs * Time.fixedDeltaTime);

            rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
            rb.MoveRotation(targetRotation);
        }
    }

    private void Jump()
    {
        if(_isJumping)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }
}
