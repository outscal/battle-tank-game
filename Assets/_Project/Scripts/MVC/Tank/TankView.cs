using UnityEngine;
using UnityEngine.UI;
using Tanks.MVC;
using System;

public class TankView : MonoBehaviour
{
    public TankType tankType;
    public TankController tankController;

    internal Rigidbody rb;

    internal float playerTurnHorizontal = 0f;
    internal float playerMoveVertical = 0f;
    internal bool fire1 = false;
    internal bool fire0 = false;
    internal bool fire3 = false;

    public Slider sliderHealth;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    public Rigidbody shellPrefab;
    public Transform fireTransform;
    public Slider aimSlider;
    
    public bool fired;

    internal bool tankDead;
    private void Awake()
    {
        InitializeComponenets();
    }
    private void Start()
    {
        Debug.Log("Tank View Created");
        tankController.StartFunction();
        //chargeSpeed = (maxLaunchForce - minLaunchForce) / maxChargeTime;
    }
    private void Update()
    {
        PlayerTankInput();
        tankController.FireControl();
        //tankController.CheckDamage();
    }
    private void InitializeComponenets()
    {
        rb = FindObjectOfType<Rigidbody>();

    }
    protected virtual void PlayerTankInput()
    {
        playerTurnHorizontal = Input.GetAxisRaw("Horizontal");
        playerMoveVertical = Input.GetAxisRaw("Vertical");

        fire1 = Input.GetMouseButtonDown(0);
        fire0 = Input.GetMouseButton(0);
        fire3 = Input.GetMouseButtonUp(0);
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

    internal void TakeDamage(float damage)
    {
        tankController.TakeDamage(damage);
    }
}
