using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class is respponsible to Create, Destroy and Manage all the Tank MVCs in the Game.
/// </summary>
public class TankService : SingletonGeneric<TankService>
{
    public PlayerTankViewList playerTankViewList;
    private TankController tankController;
    public TankScriptableObjectList TankList;
    //public BulletScriptableObjectList BulletList;
    public Joystick LeftJoyStick;
    public Joystick RightJoyStick;
    //public Button FireButton;
    public Camera playerCamera;



    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        tankController = CreateNewPlayerTank();

    }

    // This Function Creates a new Player Tank MVC & also set all the required references and returns the Tank Controller of the same.
    private TankController CreateNewPlayerTank()
    {
        TankModel tankModel = new TankModel(TankList.TankSOList[2]);
        TankController tankController = new TankController(tankModel, playerTankViewList.TankViewList[1]);
        tankController.SetJoyStickReferences(LeftJoyStick, RightJoyStick);
        //tankController.SetCameraReference(playerCamera);
        tankController.TankView.SetTankControllerReference(tankController);
        return tankController;
    }

    // This Function is used to communicate with Bullet Service Script when input to fire a bullet is recieved.
    //public void Fire()
    //{
    //    BulletService.Instance.FireBullet(tankController.TankView.BulletSpawner.transform, tankController.TankModel.BulletType);
    // }

}