using UnityEngine;
using Tanks.MVC;

public class TankView : MonoBehaviour
{
    public TankType tankType;
    public TankController tankController;

    internal Rigidbody rb;

    internal float playerTurnHorizontal = 0f;
    internal float playerMoveVertical = 0f;

    private void Awake()
    {
        InitializeComponenets();
    }
    private void Start()
    {
        Debug.Log("Tank View Created");
    }
    private void Update()
    {
        PlayerTankInput();
    }
    private void InitializeComponenets()
    {
        rb = FindObjectOfType<Rigidbody>();
    }
    protected virtual void PlayerTankInput()
    {
        playerTurnHorizontal = Input.GetAxisRaw("Horizontal");
        playerMoveVertical = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        ControlTank();
    }
    public void ControlTank()
    {
        tankController.PlayerTankMovement();
        tankController.PlayerTankRotation();
    }
}
