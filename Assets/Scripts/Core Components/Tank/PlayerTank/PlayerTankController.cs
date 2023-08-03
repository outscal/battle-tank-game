using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankController : TankController
{

    PlayerTankModel PlayerTankModel;
    PlayerTankView PlayerTankView;

    BulletScriptableObject BulletScriptableObject;

    Joystick joystick;
    Button shootButton;

    bool triggerShoot;

    public PlayerTankController(PlayerTankModel playerTankModel, PlayerTankScriptableObject playerTankScriptableObject, Joystick _joystick, Button _shootButton) : base(playerTankModel, playerTankScriptableObject.PlayerTankViewPrefab)
    {
        joystick = _joystick;
        shootButton = _shootButton;

        PlayerTankModel = (PlayerTankModel)TankModel;
        PlayerTankView = (PlayerTankView)TankView;

        PlayerTankView.PlayerTankController = this;

        if (joystick == null)
            throw new NullReferenceException("joystick object isn't available");
        if (_shootButton == null)
            throw new NullReferenceException("shootButton object isn't available");

        BulletScriptableObject = playerTankScriptableObject.BulletScriptableObject;
        if (BulletScriptableObject == null)
            throw new NullReferenceException("BulletScriptableObject object isn't available");

        triggerShoot = false;
        shootButton.onClick.AddListener(ShootButtonAction);
    }

    public void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        if (horizontal >= .2f || horizontal <= -.2f || vertical >= .2f || vertical <= -.2f)
            handleMovement(horizontal, vertical, Time.deltaTime);
    }

    public void FixedUpdate()
    {
        if (triggerShoot)
        {
            shoot();

            triggerShoot = false;
        }
    }

    void ShootButtonAction()
    {
        triggerShoot = true;
    }

    protected override void shoot()
    {
        BulletModel bulletModel = new BulletModel(BulletScriptableObject);
        BulletController bulletController = new BulletController(bulletModel, BulletScriptableObject.BulletViewPrefab);

        bulletController.SetDirection(PlayerTankView.Position, PlayerTankView.Rotation, PlayerTankView.LocalScale);
    }
}