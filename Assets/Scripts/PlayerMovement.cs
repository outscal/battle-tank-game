using UnityEngine;
using Assets.Scripts.MVC.Tank;
public class PlayerMovement : Singleton<PlayerMovement>
{
    [SerializeField] private float speed = 10f;
    private FixedJoystick fixedjoyStick;
    //public FixedJoystick fixedjoyStick;
    TankService ts;
    public TankView tankView{get;}

    public PlayerMovement()
    {
        //fixedjoyStick = GameObject.FindWithTag("Joystick");
        SetPlayerMovementReference(fixedjoyStick);
       
    }
    public void nextPsoition()
    {
        float horizontalInput = fixedjoyStick.Horizontal;
        float verticalInput = fixedjoyStick.Vertical;
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0,
            verticalInput * speed * Time.deltaTime);
        
    }

    public void SetPlayerMovementReference(FixedJoystick joystick)
    {
        fixedjoyStick = joystick;
    }

    void Update()
    {
        Debug.Log("Update Accessed");
        float verticalInput = fixedjoyStick.Vertical;
        float horizontalInput = fixedjoyStick.Horizontal;
        transform.position = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0,
            verticalInput * speed * Time.deltaTime);
    }

    
}