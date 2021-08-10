using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{

    public float rotateSpeed = 100f;
    public float movementSpeed = 400f;
    public static Transform playerTransform;
    private Rigidbody rb;
    void Awake()
    {
        playerTransform = gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        Debug.Log(playerTransform.position);
    }

    void Update()
    {

        float movement = Input.GetAxisRaw("Vertical");
        float rotation = Input.GetAxisRaw("Horizontal");

        Vector3 move = transform.position;
        move += transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
        rb.MovePosition(move);


        Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}

// Move();
// Roatation();


// Vector3 moveDirection = new Vector3(rotation, 0, movement);
// moveDirection.Normalize();
// if (moveDirection != Vector3.zero)
// {
// Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
// Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);

// rb.MoveRotation(rb.rotation * deltaRotation);



// }

// void FixedUpdate()
// {
// }

// void Move()
// {
//     Debug.Log("move");


// }

// void Roatation()
// {

//     Debug.Log("rotation");

//     Vector3 moveDirection = new Vector3(rotation, 0, movement);
//     moveDirection.Normalize();
//     if (moveDirection != Vector3.zero)
//     {
//         // Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
//         // Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);

//         // rb.MoveRotation(rb.rotation * deltaRotation);

//         Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
//         Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//         rb.MoveRotation(rb.rotation * deltaRotation);
//     }

// }



// }
// }



// transform.Translate(moveDirection * speed * Time.deltaTime);


// Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

// transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);



// move += transform.forward * 20 * Time.fixedDeltaTime;


// horizontal = Input.GetAxisRaw("Horizontal");
// vertical = Input.GetAxisRaw("Vertical");

// if (Input.GetKey(KeyCode.A))
// {
//     Debug.Log("keypressed");
//     horizontal = -1;
// }
// if (Input.GetKey(KeyCode.D))
// {
//     horizontal = 1;
// }
// if (Input.GetKeyDown(KeyCode.W))
// {
//     vertical = 1;
// }
// if (Input.GetKeyDown(KeyCode.S))
// {
//     vertical = -1;
// }
// Movement();




//   void Update()
//     {

//         if (Input.GetKey(KeyCode.A))
//         {
//             Debug.Log("left");
//             Vector3 move = transform.position;
//             move += (transform.forward * speed * Time.fixedDeltaTime);
//             rb.MovePosition(move);
//         }
//         if (Input.GetKey(KeyCode.D))
//         {
//             Debug.Log("left");
//             Vector3 move = transform.position;
//             move -= (transform.forward * speed * Time.fixedDeltaTime);
//             rb.MovePosition(move);
//         }
//         if (Input.GetKeyDown(KeyCode.W))
//         {
//             Debug.Log("roLeft");
//             rotation = 1;
//             Vector3 vector = new Vector3(0f, rotation, 0f);
//             Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//             rb.MoveRotation(rb.rotation * deltaRotation);

//         }
//         if (Input.GetKeyDown(KeyCode.S))
//         {
//             Debug.Log("S");
//             rotation = -1;
//             Vector3 vector = new Vector3(0f, rotation, 0f);
//             Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//             rb.MoveRotation(rb.rotation * deltaRotation);

//         }

// void Movement()
// {

// dir = new Vector3(horizontal, 0, vertical).normalized;
// Debug.Log(dir);
// if (dir.magnitude >= 0.1f)
// {
//     float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
//     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
//     transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);



//     controller.Move(dir * speed * Time.deltaTime);
// }

// }