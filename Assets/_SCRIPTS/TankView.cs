using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TankView : MonoBehaviour
{
    public float tankSpeed = 500;
    public float tankRotationSpeed =100;
    private Vector3 currentEulerAngles;
    Rigidbody rb; 
     
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal1");
        float verticalInput = Input.GetAxisRaw("Vertical1");

        MovementController(horizontalInput, verticalInput); 

    }
    private void MovementController(float horizontalInput, float verticalInput)
    {
        currentEulerAngles += new Vector3(0, horizontalInput, 0) * Time.deltaTime * tankRotationSpeed;
        transform.eulerAngles = currentEulerAngles;      
        rb.velocity = transform.forward * verticalInput * Time.deltaTime * tankSpeed;
    }

    public void UpdateTankModel()
    {



    }

}
