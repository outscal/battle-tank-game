using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.View;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType tankType;
        public string tankName;
        public float speed;
        public float turn;
        public float health;
        public BulletType BulletType;
        public TankView TankView;

    }

    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }
}