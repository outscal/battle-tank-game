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
    public BulletScriptableObjectList BulletList;
    public Joystick LeftJoyStick;
    public Joystick RightJoyStick;
    public Button FireButton;
    public CameraController cam;
    //public EnemyTank enemyTank;
    //public ETankView enemyTank;
    //public BulletService bulletService;

    //bullet and tank equalized
    public int TType;
    //public TankType tType;

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
        TankController tankController = new TankController(tankModel, playerTankViewList.TankViewList[(int)TType]);
        tankController.SetJoyStickReferences(LeftJoyStick, RightJoyStick);
        //tankController.SetCameraReference(playerCamera);
        cam.playerTank = tankController.GetTransform();
        tankController.TankView.SetTankControllerReference(tankController);
        ///enemyTank.Player = tankController.GetTransform();
        return tankController;
        
    }


     //This Function is used to communicate with Bullet Service Script when input to fire a bullet is recieved.
    public void Fire()
    {
        Debug.Log("fire");
        //Rigidbody shellInstance = GameObject.Instantiate(TankView.shellPrefab, TankView.BulletSpawner.position, TankView.BulletSpawner.rotation, TankView.BulletSpawner) as Rigidbody;
        BulletService.Instance.FireBullet(tankController.TankView.BulletSpawner.transform, tankController.TankModel.BulletType);

        //shellInstance.velocity = TankModel.CurrentLaunchForce * TankView.BulletSpawner.forward;
        //TankModel.CurrentLaunchForce = TankModel.MinLaunchForce;

    }

    
}