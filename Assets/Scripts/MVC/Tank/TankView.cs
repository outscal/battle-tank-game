using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{

    private TankController tankController;
    
    private float movementInput;
    private float rotationInput;
    public Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f,3f,-5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if(movementInput != 0)
        {
           
           tankController.Move(movementInput);
           
        }
          
        if(rotationInput != 0)
        {
           tankController.Rotate(rotationInput);
           
        } 
        /// <summary>
        /// Line 26 to 34 inside a separate function to clean up monobehaviour life cycle;
        /// </summary>
        
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
