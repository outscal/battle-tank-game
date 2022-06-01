using System.Drawing;
using System;
using UnityEngine;



    
    
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Scriptableobject/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankTypeEnum TankType;
        public string TankName;
        public float health;
        public float speed;
        public float rspeed;
        public Color color;
    }

    
    

