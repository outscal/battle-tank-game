using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class TankController
{
    //---------------------VALUES--------------------------
    //PRIVATE VALUES
    private TankModel TankModel { get; }
    private TankView TankView { get; }    
    private Rigidbody tank_Rigidbody;
    private float tank_MovementInputValue;
    private float tank_TurnInputValue;
    private const string tank_MovementAxisName = "Vertical1";
    private const string tank_TurnAxisName = "Horizontal1";
    private float nextFireTime = 0f;

    //PUBLIC VALUES
    public bool tank_IsMoving = false;
    public bool tank_IsTurning = false;
    public float fireRate = 0.1f;

    //--------------------FUNCTIONS-------------------------
    //PRIVATE FUNCTIONS
    private void EngineAudio()
    {
        //Engine Audio Script for idle and running status.
    }
    private void SetDefaultMoveAndTurnValues()
    {
        tank_MovementInputValue = 0f;
        tank_TurnInputValue = 0f;
    }


    //PUBLIC FUNCTIONS
    public void Initialize()
    {
        tank_Rigidbody = TankView.GetRigidBody();
    }
    public void Simulate()
    {
        tank_MovementInputValue = Input.GetAxis(tank_MovementAxisName);
        tank_TurnInputValue = Input.GetAxis(tank_TurnAxisName);

        tank_IsMoving = Mathf.Abs(tank_MovementInputValue) > 0.1f;
        tank_IsTurning = Mathf.Abs(tank_TurnInputValue) > 0.1f;

        if(Input.GetMouseButton(0) && Time.time >= nextFireTime) { TankView.Shoot(); nextFireTime = Time.time + fireRate; }

        EngineAudio();
    }
    public TankController(TankModel tankModel, TankView tankView)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<TankView>(tankView);
        TankView.SetTankController(this);
        
        SetDefaultMoveAndTurnValues();
    }

    public void Move()
    {
        Vector3 movement = TankModel.tank_Speed * tank_MovementInputValue * Time.deltaTime * TankView.transform.forward;
        tank_Rigidbody.MovePosition(tank_Rigidbody.position + movement);
    }

    public void Turn()
    {
        float turn = TankModel.tank_TurnSpeed * tank_TurnInputValue * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        tank_Rigidbody.MoveRotation(tank_Rigidbody.rotation * turnRotation);
    }

    public void ShootShell(ShellService shellService)
    {
        shellService.SpawnShell(shellService.transform);
    }
}