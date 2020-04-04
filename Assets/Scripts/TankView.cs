using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{

     float horizontalInput;
     float verticalInput;
    public float rotatingSpeed;
    public float movingSpeed;
    private Vector3 currentEulerAngles;
    private Vector3 currentTankSpeed;
    public Rigidbody rb;

    private void Start()
    {
        Debug.Log("TankView Has Started");   
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("HorizontalUI");
        verticalInput = Input.GetAxisRaw("VerticalUI");
        moveTank();
    }


    private void moveTank()
    {
        //transform.rotation = new Vector3(horizontalInput* rotatingSpeed, )
        currentEulerAngles += new Vector3(0, horizontalInput,0) * Time.deltaTime * rotatingSpeed;
        transform.eulerAngles = currentEulerAngles;
        //currentTankSpeed += new Vector3(0, 0, verticalInput) * Time.deltaTime * movingSpeed;
        //transform.forward = currentTankSpeed;
        rb.velocity = transform.forward * verticalInput * Time.deltaTime * movingSpeed;

    }

}
