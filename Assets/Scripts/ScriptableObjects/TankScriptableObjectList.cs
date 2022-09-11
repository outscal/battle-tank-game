using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "Scriptableobject/NewTankScriptableObjectList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
       
    }