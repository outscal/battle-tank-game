using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{

public class PlayerTank : SingletonGenerics<PlayerTank>
{
    private float playerTurnHorizontal = 0f;
    private float playerMoveVertical = 0f;
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
        //playerTurnHorizontal = joystick.Horizontal;
        //playerMoveVertical = joystick.Vertical;

        playerTurnHorizontal = Input.GetAxisRaw("Horizontal");
        playerMoveVertical = Input.GetAxisRaw("Vertical");
    }
    private void PlayerTankMovement()
    {
        Vector3 movement = transform.forward * playerMoveVertical * playerSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        float turn = playerTurnHorizontal * playerTurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
} 
}