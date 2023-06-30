using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    private TankController tankController;
    private float speed;
   


    public TankView()
    {
        speed = tankController.GetTankModel().moveSpeed;
    }

    private void FixedUpdate()
    {
        tankController.MoveTank(speed);
       
    }


    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
     public Joystick GetJoystick()
    {
        return joystick;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
