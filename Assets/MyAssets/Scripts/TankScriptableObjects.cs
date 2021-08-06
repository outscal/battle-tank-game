using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattaleTank
{

    [CreateAssetMenu(fileName = "TankScriptableObjects", menuName = "ScriptableObject/NewTank")]
    public class TankScriptableObjects : ScriptableObject
    {
        public TankType tankType;

        public string tankName;
        public TankView tankView;
        public float movementSpeed;
        public float rotationSpeed;
        public float health;
    }
}