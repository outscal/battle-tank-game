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

    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;

    public float m_CurrentLaunchForce;
    public float m_ChargeSpeed;
    public bool m_Fired;

    internal bool tankDead;
    private void Awake()
    {
        InitializeComponenets();
    }
    private void Start()
    {
        Debug.Log("Tank View Created");
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
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
