using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f; 
    public float turnSpeed = 180f; 

    Rigidbody rb;

    private float xMove;
    private float zMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //rb equals the rigidbody on the player
    }

    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal1");
        zMove = Input.GetAxisRaw("Vertical1");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    void Move()
    {
        Vector3 movement = transform.forward * xMove * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void Turn()
    {
        float turn = zMove * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
