using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TankService : GenericSingleton<TankService> 
{
    private TankType playerTank;
    [SerializeField] private List<TankType> EnemyTanks = new List<TankType>();
    [SerializeField] int enemyTankCount;
    [SerializeField] private List<EnemyTankController> EnemyTanksControllers = new List<EnemyTankController>();
    [SerializeField] private TankTypes tanks;
    public Coroutine destroyAll;

    public Follower playerTankFollower;
    public PlayerTankController playerTankController;

    protected override void Start()
    {
        StartGame();
    }

    public TankView getPlayerTankView() => playerTank.tankview;
    void StartGame()
    {
        playerTankController = CreatePlayerTank();
        CreateEnemyTanks();
    }

    public void ServiceLaunchBullet(BulletType _bulletTyoe, TransformSet _launch)
    {
        BulletService.Instance.FireBullet(_bulletTyoe, _launch);
    }

    public void destroyAllTanks()
    {
        destroyAll = StartCoroutine(destroyAllEnemies());
        GameManager.Instance.destroyWorld();
    }

    private IEnumerator destroyAllEnemies()
    {
        foreach (TankController tank in EnemyTanksControllers)
        {
            tank.DestroyTank();
            yield return tank.tankView.destroyThis;
        }
        EnemyTanksControllers.Clear();
        EnemyTanks.Clear();
    }

    private TankType chooseRandomTank()
    {
        int n = Random.Range(0, tanks.Types.Count);
        return tanks.Types[n];    
    }
    private PlayerTankController CreatePlayerTank()
    {
        playerTank = chooseRandomTank();
        TankModel tankModel = new TankModel(playerTank.speed, playerTank.health, playerTank.bulletType);
        PlayerTankController tankController = new PlayerTankController(tankModel, playerTank.tankview);
        return tankController;
    }
    private void CreateEnemyTanks()
    {
        //EnemyTanks.Clear();
        //EnemyTanksControllers.Clear();
        for (int i = 0; i < enemyTankCount; i++)
        {
            EnemyTanks.Add(chooseRandomTank());
            TankModel tankModel = new TankModel(EnemyTanks[i].speed, EnemyTanks[i].health, EnemyTanks[i].bulletType);
            EnemyTankController tankController = new EnemyTankController(tankModel, EnemyTanks[i].tankview);
            EnemyTanksControllers.Add(tankController);
        }
    }

}
