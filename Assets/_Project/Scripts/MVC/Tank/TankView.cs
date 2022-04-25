using UnityEngine;
using UnityEngine.UI;
using Tanks.MVC;

public class TankView : MonoBehaviour
{
    public TankType tankType;
    public TankController tankController;
    
    internal Rigidbody rb;
    internal float playerTurnHorizontal = 0f;
    internal float playerMoveVertical = 0f;
    internal bool fire = false;
    public Slider sliderHealth;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    internal float currentHealth;
    internal bool tankDead;
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
        tankController.CheckDamage();
    }
    private void InitializeComponenets()
    {
        rb = FindObjectOfType<Rigidbody>();
    }
    protected virtual void PlayerTankInput()
    {
        playerTurnHorizontal = Input.GetAxisRaw("Horizontal");
        playerMoveVertical = Input.GetAxisRaw("Vertical");
        fire = Input.GetMouseButtonDown(0);
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
