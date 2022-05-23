using System;
using UnityEngine;



    
    
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Scriptableobject/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankTypeEnum TankType;
        public string TankName;

        public float speed;
        public float rspeed;
    }

    
    

