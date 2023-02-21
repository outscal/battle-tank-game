using UnityEngine;

public class TankMovementController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 180f;

    private float movementInputValue; // acceleration
    private float turnInputValue; // direction 
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Get input
        movementInputValue = Input.GetAxis("Vertical1");
        turnInputValue = Input.GetAxis("Horizontal1");
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        // move/ accelerate the tank
        Vector3 movement = transform.forward * movementInputValue * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

    }

    private void Turn()
    {
        // turn along its y- axis
        float turnValue = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnValue, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
