using System;
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    [SerializeField] Joystick joystick;
    [SerializeField] float horizontal,vertical;
    [SerializeField] float speed=8f;
    [SerializeField] GameObject TankHead;
    
    

   

    void FixedUpdate()
    {
        horizontal = joystick.Horizontal;

        vertical = joystick.Vertical;
        PlayerMovement(horizontal,vertical);
    }



    private void PlayerMovement(float horizontal, float vertical)
    {
            //Move player 
            Vector3 position = transform.position;
            position.x += horizontal * speed * Time.deltaTime;
            position.y = 0;
            position.z += vertical * speed * Time.deltaTime;
            transform.position = position;

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            TankHead.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
}
