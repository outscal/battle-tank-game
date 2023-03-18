using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour {

    private TankController tankController;

    private float movement;
    private float rotation;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
    }

    private void Update()
    {
        Movement();

        if (movement != 0)
            tankController.Move(movement, tankController.GetTankModel().GetMovementSpeed());

        if (rotation != 0)
            tankController.Rotate(rotation, tankController.GetTankModel().GetRotationSpeed());
    }

    private void Movement()
    {
        movement = Input.GetAxisRaw("VerticalUI");
        rotation = Input.GetAxisRaw("HorizontalUI");
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public Rigidbody GetRigiBody()
    {
        return rb;
    }
}
