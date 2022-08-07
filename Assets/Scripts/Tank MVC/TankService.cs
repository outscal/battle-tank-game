using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This Class is respponsible to Create, Destroy and Manage all the Tank MVCs in the Game.
/// </summary>

public class TankService : GenericSingleton<TankService>
{
    //Refernces.
    [SerializeField] private Joystick joystick;
    [SerializeField] private TankView tankPrefab;

    private TankController tankController;

    private void Start()
    {
        CreateNewPlayerTank();
    }

    // This Function Creates a new Player Tank MVC & also set all the required references and returns the Tank Controller for the same.
    private void CreateNewPlayerTank()
    {
        TankModel tankModel = new TankModel(10, 220);
        tankController = new TankController(tankModel, tankPrefab, joystick);
    }
}
