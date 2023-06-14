using BattleTank.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController tankController;
    
    [SerializeField] Rigidbody tankRigidbody;
    public TankType tankType;

    private float movement;
    private float rotation;

    void Start()
    {
        Debug.Log("Tank view is created : " + tankController.TankView);
    }

    void Update()
    {
        Movement();

        if(movement != 0)
        {
            tankController.Move(movement, tankController.TankModel.movementSpeed);
        }
        else
        {
            tankRigidbody.velocity = Vector3.zero;
        }
        

        if(rotation != 0)
        {
            tankController.Turn(rotation, tankController.TankModel.rotationSpeed);
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
}