using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.View;
using ScriptableObj;

namespace Scriptables
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        public TankType tankType;
        public string tankName;
        public float speed;
        public float turn;
        public float health;
        public BulletScriptableObject BulletType;
        public TankView TankView;
    }
}