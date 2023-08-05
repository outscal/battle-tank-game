using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankController : TankController
{

    PlayerTankModel PlayerTankModel;
    PlayerTankView PlayerTankView;

    Joystick joystick;
    Button shootButton;

    bool triggerShoot;

    public PlayerTankController(PlayerTankScriptableObject playerTankScriptableObject, Joystick _joystick, Button _shootButton) : base((TankScriptableObject)playerTankScriptableObject)
    {
        if (_joystick == null)
            throw new NullReferenceException("joystick object isn't available");
        if (_shootButton == null)
            throw new NullReferenceException("shootButton object isn't available");

        joystick = _joystick;
        shootButton = _shootButton;

        PlayerTankModel = new PlayerTankModel(playerTankScriptableObject);
        TankModel = (TankModel)PlayerTankModel;

        PlayerTankView = GameObject.Instantiate<PlayerTankView>(PlayerTankModel.PlayerTankViewPrefab);
        TankView = (TankView)PlayerTankView;

        PlayerTankView.PlayerTankController = this;
        TankView.TankController = (TankController)this;

        triggerShoot = false;
        shootButton.onClick.AddListener(ShootButtonAction);
    }

    public void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        // increasing joystick senstivity
        if (horizontal >= .2f || horizontal <= -.2f || vertical >= .2f || vertical <= -.2f)
            HandleMovement(horizontal, vertical, Time.deltaTime);
    }

    public void FixedUpdate()
    {
        if (triggerShoot)
        {
            Shoot();
            triggerShoot = false;
        }
    }

    void ShootButtonAction()
    {
        triggerShoot = true;
    }
}