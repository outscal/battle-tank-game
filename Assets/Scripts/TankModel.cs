using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    private TankController tankController;
    private TankView tankView;
    public TankType _tankType{get;}
    public int Speed{get;}
    public float Health;
    public TankModel(TankScriptableObject tankScriptableObject){
        _tankType = tankScriptableObject._tankType;  
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
    }
    
    public TankModel(TankType tankType, int speed, float health){
        _tankType = tankType;
        Speed =  speed;
        Health = health;

    }

    public void SetHealth(int num){
        Health = num;
    }

    public void SetTankController(TankController _tankController){
        tankController = _tankController;
    }
}