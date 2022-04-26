using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    TankController m_tankController;

    Vector2 m_tankMovement;




    private CharacterController m_CharacterController;


    private Player playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField]
    private float playerSpeed = 10.0f;
    private void Awake()
    {
        //assigning an object of the input action to the input action reference
        playerInput = new Player();
        //getting the reference for character controller
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    public void SetTankController(TankController tankController)
    {
        m_tankController = tankController;
    }

    public void Update()
    {
        Vector2 movementInput = playerInput.PlayerMain.Movement.ReadValue<Vector2>();
        m_tankController.Move(movementInput, m_tankController.GetTankModel().Speed, groundedPlayer, playerVelocity, m_CharacterController, gameObject);
    }


}

