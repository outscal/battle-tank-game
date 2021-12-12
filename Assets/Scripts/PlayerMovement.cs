using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private float speed;
    [SerializeField] private FixedJoystick fixedjoyStick;

    void nextPsoition()
    {
        
        
    }

    void Update()
    {
        float horizontalInput = fixedjoyStick.Horizontal;
        float verticalInput = fixedjoyStick.Vertical;
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0,
            verticalInput * speed * Time.deltaTime);
    }
}
