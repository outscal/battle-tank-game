using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement;
    private float rotation;
    [SerializeField] private Rigidbody rb;
    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTankController(TankController tankcontroller)
    {
        tankController = tankcontroller;
    }
    public void GetJoyStick(Joystick joyStick)
    {
        joystick = joyStick;
    }
    // Update is called once per frame
    void Update()
    {
        
        Movement();
        
        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().moveSpeed);
        }
        if(rotation != 0)
        {
            tankController.Turn(rotation, tankController.GetTankModel().TurnSpeed);
        }
    }
    
    private void Movement()
    {
        movement = joystick.Vertical;
        rotation = joystick.Horizontal;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}