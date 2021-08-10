using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    [CreateAssetMenu(fileName = "TankScriptableObjects", menuName = "ScriptableObject/NewTank")]
    public class TankScriptableObjects : ScriptableObject
    {

        public TankView tankView;
        public string tankName;
        public TankType tankType;
        public float movementSpeed;
        public float rotationSpeed;
        public float health;
        public float fireRate;
        public string bulletType;
    }

    [CreateAssetMenu(fileName = "TankSO_List", menuName = "ScriptableObjectList/TankListOfSO")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObjects[] tanks;
    }


}