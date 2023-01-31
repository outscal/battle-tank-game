using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : Singleton<PlayerTank>
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float TurnSpeed = 5f;
    [SerializeField] private Joystick joystick;
    protected override void Awake() 
    {
        rb.GetComponent<Rigidbody>();
    }
    private void Update() 
    {
        Move();
        Turn();
    }
    void Move()
    {
        Vector3 moveForward = transform.forward * joystick.Vertical * Speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveForward);
    }
    void Turn()
    {
        float turn = joystick.Horizontal * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
} 