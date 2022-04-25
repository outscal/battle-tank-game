using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tanks.MVC;

public class TankService : TankSingletonGenerics<TankService>
{
    public TankView tankView;
    public TankModel playerModel;
    public TankModel enemyModel;

    public Transform spawnPlayer;
    public Transform spawnEnemy;

    public TankScriptableObjectList tankScriptableObjectList;
    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        CreatePlayerTank();
        CreateEnemyTank();
    }

    private TankController CreatePlayerTank()
    {
        int index = Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[index];
        Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        playerModel = new TankModel(tankScriptableObject);
        TankController playerTank = new TankController(playerModel, tankView, spawnPlayer.position);
        return playerTank;
    }

    private TankController CreateEnemyTank()
    {
        int index = Random.Range(0, tankScriptableObjectList.tanks.Length);
        TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[index];
        Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
        enemyModel = new TankModel(tankScriptableObject);
        TankController enemyTank = new TankController(playerModel, tankView, spawnEnemy.position);
        return enemyTank;
    }
}
    //private void StartGame()
    //{
    //    for (int i = 0; i < tankScriptableObjectList.tanks.Length; i++)
    //        CreateNewTank(i);
    //}

    //private TankController CreateNewTank(int index)
    //{
    //    TankScriptableObject tankScriptableObject = tankScriptableObjectList.tanks[index];
    //    Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
    //    TankModel model = new TankModel(tankScriptableObject);
    //    TankController tank = new TankController(model, tankView);
    //    return tank;
    //}