using UnityEngine;
using UnityEngine.UI;
using Tanks.MVC;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class TankView : MonoBehaviour,IDamagable
{
    public TankType tankType;
    public TankController TankController;
    
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
        //Debug.Log("Tank View Created");
        TankController.StartFunction();
        //ChangeState(startingState);

    }
    private void Update()
    {
        PlayerTankInput();
        TankController.FireControl();
    }
    private void InitializeComponenets()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void PlayerTankInput()
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
    private void ControlTank()
    {
        TankController.PlayerTankMovement();
        TankController.PlayerTankRotation();
    }
    void IDamagable.TakeDamage(float damage)
    {
        //Debug.Log("Player Taking Damage" + damage);
        TankController.ApplyDamage(damage);
    }
}
