using System;
using UnityEngine;

public class PlayerTankController : TankController
{

    PlayerTankModel PlayerTankModel;
    PlayerTankView PlayerTankView;

    Joystick joystick;

    public PlayerTankController(PlayerTankModel _playerTankModel, PlayerTankView _playerTankViewPrefab, Joystick _joystick) : base(_playerTankModel, _playerTankViewPrefab)
    {
        joystick = _joystick;

        PlayerTankModel = (PlayerTankModel)TankModel;
        PlayerTankView = (PlayerTankView)TankView;

        PlayerTankView.PlayerTankController = this;

        if (joystick == null)
            throw new NullReferenceException("joystick object isn't available");
    }

    public void Update()
    {
        float horizontal = joystick.Horizontal;
        horizontal = horizontal >= .2f || horizontal <= -.2f ? horizontal : 0;
        float vertical = joystick.Vertical;
        vertical = vertical >= .2f || vertical <= -.2f ? vertical : 0;

        Vector3 position = PlayerTankView.Position;
        position.x += horizontal * PlayerTankModel.Speed * Time.fixedDeltaTime;
        position.z += vertical * PlayerTankModel.Speed * Time.fixedDeltaTime;

        Vector3 rotation = new Vector3(horizontal, position.y, vertical);

        PlayerTankView.Rotation = Quaternion.LookRotation(rotation);
        PlayerTankView.Position = position;
    }
}