using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{

    private TankController tankController;
    
     private float movementInput;
    private float rotationInput;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if(movementInput != 0)
        {
           tankController.Move(movementInput,15);
        }
          
        if(rotationInput != 0)
        {
           tankController.Rotate(rotationInput,40);
        } 
        
    }

    private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput =  Input.GetAxis("Horizontal");
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    
}
