using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    private int playerId;
    private TankView tankView;
    public TankType TankType{get;}
    // public int Speed{get;}
    public int Speed {get; set;}
    public float Health {get; set;}
    public TankModel(TankScriptableObject tankScriptableObject){
        TankType = tankScriptableObject.tankType;  
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        playerId = Random.Range(1, 10000);
    }
    
    // public TankModel(TankType tankType, int speed, float health){
    //     TankType = tankType;
    //     Speed =  speed;
    //     Health = health;
    // }

    public void SetTankController(TankController _tankController){
        tankController = _tankController;
    }
}