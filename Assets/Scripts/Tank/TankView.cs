using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    [SerializeField] Rigidbody tankRigidbody;

    float movement;
    float rotation;

    void Start()
    {
        Debug.Log("Tank view is created");
        CameraSetup();
    }

    void Update()
    {
        Movement();

        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);
        }

        if(rotation != 0)
        {
            tankController.Turn(rotation, tankController.GetTankModel().rotationSpeed);
        }
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    void Movement()
    {
        movement = Input.GetAxisRaw("Horizontal1");
        rotation = Input.GetAxisRaw("Vertical1");
    }

    public Rigidbody GetRigidbody()
    {
        return tankRigidbody;
    }

    void CameraSetup()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(this.transform);
        cam.transform.position = new Vector3(0f, 8.1f, -13f);
        cam.transform.eulerAngles = new Vector3(15f,0f,0f);
    }
    
}
