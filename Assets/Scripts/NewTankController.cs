using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTankController : MonoBehaviour
{
    public float speed = 5;

    
   
    
    
   

   
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
        float y = 20 * Time.fixedDeltaTime;
        float z = 0;

        Vector3 Angles = new Vector3(x, y, z);
        transform.Rotate(Angles, Space.Self);
        
    }

    private void VerticalMovement()
    {
        // Vertical movement: w and s ; up(direction is z) and down(direction is -z)
         transform.Translate(Vector3.forward * speed *  Time.fixedDeltaTime);
        
    }
}
