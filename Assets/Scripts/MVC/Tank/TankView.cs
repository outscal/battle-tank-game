using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private Joystick joystick;
    private TankController tankController;
    [SerializeField] private float speed = 30F;
    public TankView()
    { 
    }
    private void FixedUpdate()
    { 
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed);
        if(joystick.Horizontal !=0 || joystick.Vertical != 0)
        {
           transform.rotation =  Quaternion.LookRotation(rb.velocity);
        }
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
<<<<<<< HEAD
=======



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

>>>>>>> 23d1a0e0085850cb25af8fffb5e5acfa993ddf3a
}
