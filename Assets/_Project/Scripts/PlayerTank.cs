using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankSingletonGenerics<PlayerTank>
{
    private float playerMoveHorizontal = 0f;
    private float playerTurnVertical = 0f;
    private Rigidbody rb;
    [SerializeField] private float playerSpeed = 12f;
    [SerializeField] private float playerTurnSpeed = 180f;

    public Joystick joystick;

    protected override void Awake()
    {
        base.Awake();
        InitializeComponenets();
        //playerTank awake functions
    }
    private void Update()
    {
        PlayerTankInput();
    }
    private void FixedUpdate()
    {
        PlayerTankMovement();
    }
    
    private void InitializeComponenets()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void PlayerTankInput()
    {
        playerMoveHorizontal = joystick.Horizontal;
        playerTurnVertical = joystick.Vertical;

        //playerMoveHorizontal = Input.GetAxisRaw("Horizontal");
        //playerTurnVertical = Input.GetAxisRaw("Vertical");
    }
    private void PlayerTankMovement()
    {
        Vector3 movement = transform.forward * playerTurnVertical * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = playerMoveHorizontal * playerTurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}