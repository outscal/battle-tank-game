using System;
using UnityEngine;



    
    
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "Scriptableobject/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType TankType;
        public string TankName;

        public float speed;
        public float health;
    }
    

