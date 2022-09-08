using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerTankSingleton : battleTanksSingletonGeneric<PLayerTankSingleton>
{
     
    public float m_MoveSpeed = 20f;
    public float m_TurnSpeed = 180f;

    [SerializeField] Joystick m_Joystick;
    [SerializeField] GameObject m_playerTank;

    private float m_MovementInputValue; //vertical
    private float m_TurnInputValue; //horizontal
    private Rigidbody m_Rigidbody;
    protected override void Awake()
    {
        base.Awake();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }

    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void Update()
    {
        GetJoystickInput();
    }

    private void GetJoystickInput() //get input from user
    {
        m_TurnInputValue = m_Joystick.Horizontal;   //turn the tank 
        m_MovementInputValue = m_Joystick.Vertical;       // tank movement
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }


    private void Move() //move the tank based on player input
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_MoveSpeed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);  //applying the movement to rigibody's position


        
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime; //no.of degrees to be turned based on input, turnspeed and time between frames

        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);   //making this into a y-axis only rotation

        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);  //applying the rotation to the rigidbody's rotation
    }
}



 