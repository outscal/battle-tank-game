using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel : MonoBehaviour
{
    public TankModel(TankScriptableObj tankScriptableObj)
    {
        Speed = (int)tankScriptableObj.Speed;
        Health = tankScriptableObj.Health;
        TankType = tankScriptableObj.TankType;



    }


    public int Speed { get; private set; }
    public float Health { get; private set; }
    public TankTypes TankType { get; private set; }
}