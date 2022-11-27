using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObjects/NewTankScriptableObject")]

public class TankScriptableObject : ScriptableObject
{

    public TankType TankType;
    public string TankName;
    public float Speed;
    public float Health;
    public BulletType bulletType;
    public TankView tankView;
    
}


