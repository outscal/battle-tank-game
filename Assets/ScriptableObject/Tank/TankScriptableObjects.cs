using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankServices;
using BulletSO;

namespace TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObjects", menuName = "ScriptableObject/Tank/NewTank")]
    public class TankScriptableObjects : ScriptableObject
    {
        public TankView tankView;
        public TankType tankType;
        public string tankName;
        public float movSpeed;
        public float rotSpeed;
        public float health;
        public BulletScriptableObject bulletType;
        public float fireRate;
    }
}
