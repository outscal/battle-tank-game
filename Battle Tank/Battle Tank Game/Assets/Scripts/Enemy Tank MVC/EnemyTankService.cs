using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : MonoBehaviour
{
    // public EnemyTankList enemyTankList;
    // private EnemyTankController tankController;
    // private EnemyTankType enemyTankType;
    
    // void Start()
    // {
    //     for(int i = 0; i < 3; i++)
    //     {
    //         enemyTankType = (EnemyTankType)Mathf.Floor(Random.Range(0, 2.5f));
    //         tankController = CreateEnemyTank(enemyTankType);
    //     }
        
    // }

    // private EnemyTankController CreateEnemyTank(EnemyTankType _enemyTankType)
    // {
    //     foreach(EnemyTankScriptableObjects tank in enemyTankList.enemyTanks)
    //     {
    //         if(tank.tankType == enemyTankType)
    //         {
    //             EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankList.enemyTanks[(int)enemyTankType]);
                
    //             EnemyTankController tankController = new EnemyTankController(enemyTankModel, enemyTankList.enemyTanks[(int)enemyTankType].enemyTankView);
    //             return tankController;
    //         }
    //     }
    //     return null;
    // }

    //[SerializeField]public EnemyTankView enemyTankView;
    

    public EnemyTankList enemyTankList;    

   
    void Start()
    {
        //tankView.gameObject.SetActive(true);
        StartGame();
        //cameraControl.SetStartPositionAndSize();
    }

    void StartGame()
    {
        for(int i = 0; i < 3; i++)
        {
            CreateTank(i);
        }
        //CreateEnemyTank();
    }

    private void CreateTank(int i)
    {
        int index = Random.Range(0, enemyTankList.enemyTanks.Length);
        EnemyTankScriptableObjects enemyTankSO = enemyTankList.enemyTanks[index];
        EnemyTankModel enemyTankModel = new EnemyTankModel(enemyTankSO);
        EnemyTankController tankController = new EnemyTankController(enemyTankModel, enemyTankSO.enemyTankView);         
    }
    
}
