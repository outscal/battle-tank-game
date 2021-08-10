// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class tempPlayer : MonoBehaviour
// {
//     private float rotation;
//     private float movement;
//     private float movementSpeed = 20f;
//     private float rotationSpeed = 50f;
//     private Rigidbody rigidbody;

//     void Awake()
//     {
//         rigidbody = gameObject.GetComponent<Rigidbody>();
//     }

//     private void Update()
//     {
//         Movement();
//     }
//     private void Movement()
//     {
//         rotation = Input.GetAxis("Horizontal");
//         movement = Input.GetAxis("Vertical");
//         Move();
//     }
//     public void Move()
//     {
//         // Vector3 move = gameObject.transform.transform.position += gameObject.transform.forward * movement * movementSpeed * Time.fixedDeltaTime;
//         // rigidbody.MovePosition(move);
//         Vector3 move = transform.position;
//         move += transform.forward * movement * 10 * Time.fixedDeltaTime;
//         rigidbody.MovePosition(move);
//     }

//     public void Rotate(float rotation, float rotateSpeed)
//     {
//         Vector3 moveDirection = new Vector3(rotation, 0, movement);
//         moveDirection.Normalize();
//         if (moveDirection != Vector3.zero)
//         {
//             Vector3 vector = new Vector3(0f, rotation * rotateSpeed, 0f);
//             Quaternion deltaRotation = Quaternion.Euler(vector * Time.fixedDeltaTime);
//             rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
//         }

//     }
// }
