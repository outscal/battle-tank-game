using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : SingletonGeneric<PlayerTank>
{

    [SerializeField] private Joystick joystick;
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed = 10f;
    private float rotationSpeed = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveNRotate();
       
    }

    void MoveNRotate()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // Translate the tank in the forward direction
        Vector3 forwardMovement = transform.forward * vertical * speed * Time.deltaTime;
        transform.Translate(forwardMovement, Space.World);

        // Rotate the tank based on horizontal input
        float rotation = horizontal * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);
    }
}
