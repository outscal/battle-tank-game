using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTankController : MonoBehaviour
{
    public float speed = 5;
    public  float turnspeed = 20;
    private float tnk_rotation;
    private float tnk_movement;

    void Update()
    {
        GetInput();

    }
   
    void GetInput()
    {
        tnk_movement = Input.GetAxisRaw("vertical");
        tnk_rotation = Input.GetAxisRaw("horizontal");
    }
    
   void FixedUpdate()
    {
        Tankmovement();
    }

    void Tankmovement()
    {
        // When: Input
        HorizontalMovement();
        VerticalMovement();
    }

    private void HorizontalMovement()
    {
        // How: move tank, horizontally(rotate tank) and vertically
        float x = 0;
        float y = turnspeed *tnk_rotation*Time.fixedDeltaTime;
        float z = 0;

        Vector3 Angles = new Vector3(x, y, z);
        transform.Rotate(Angles, Space.Self);
        
    }

    private void VerticalMovement()
    {
        // Vertical movement: w and s ; up(direction is z) and down(direction is -z)
       Vector3 movement =  transform.forward * tnk_movement * speed *  Time.fixedDeltaTime;
        
    }
}
