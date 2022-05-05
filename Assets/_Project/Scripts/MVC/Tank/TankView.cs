using UnityEngine;
using UnityEngine.UI;
using Tanks.MVC;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(Image))]
public class TankView : MonoBehaviour,IDamagable
{
    public TankType tankType;
    public TankController tankController;
    private TankState currentState;
    public TankState startingState;
    public TankPatrollingState tankPatrollingState;
    public TankChasingState tankChasingState;


    private Image image;

    //[SerializeField] private List<TankState> tankStates;

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
        ChangeState(startingState);

    }
    private void Update()
    {
        PlayerTankInput();
        tankController.FireControl();
        //tankController.CheckDamage();
    }
    private void InitializeComponenets()
    {
        rb = GetComponent<Rigidbody>();
        image = GetComponent<Image>();
        startingState.tankView = this;
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
        tankController.PlayerTankMovement();
        tankController.PlayerTankRotation();
    }

    //internal void TakeDamage(float damage)
    //{
    //    tankController.TakeDamage(damage);
    //}

    void IDamagable.TakeDamage(float damage)
    {
        Debug.Log("Tank Taking Damage" + damage);
        tankController.ApplyDamage(damage);
    }
    
    public void ChangeColor(Color color)
    {
        image.color = color;
    }

    public void ChangeState(TankState newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }

        currentState = newState;
        currentState.OnEnterState();
    }

    internal class setTankColor
    {
    }
}
