using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private int rotatingSpeed;
    private int movingSpeed;
    private float healthCount;
    public Renderer[] rend;
    private Material mat;
    private Color tankColor;
    private Vector3 currentEulerAngles;
    private Vector3 currentTankSpeed;
    public Rigidbody rb;

    private void Start()
    {

    }

    public void SetModel(TankModel model)
    {
        movingSpeed = model.MoveingSpeed;
        rotatingSpeed = model.MoveingSpeed;
        healthCount = model.Health;
        tankColor = model.TankColor;

        SetTankColor();
    }

    private void SetTankColor()
    {
        for (int i = 0; i < rend.Length; i++)
        {
        mat = rend[i].material;
        mat.color = tankColor;
        }
    }
    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("HorizontalUI");
        verticalInput = Input.GetAxisRaw("VerticalUI");
        moveTank();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TankService.Instance.fire();
        }
    }

    private void moveTank()
    {
        currentEulerAngles += new Vector3(0, horizontalInput,0) * Time.deltaTime * rotatingSpeed;
        transform.eulerAngles = currentEulerAngles;
        //currentTankSpeed += new Vector3(0, 0, verticalInput) * Time.deltaTime * movingSpeed;
        //transform.forward = currentTankSpeed;
        rb.velocity = transform.forward * verticalInput * Time.deltaTime * movingSpeed;

    }

}
