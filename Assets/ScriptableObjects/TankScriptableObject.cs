using System.Collections;
using UnityEngine;

namespace Assets.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTank")]
    public class TankScriptableObject : ScriptableObject
    {
        [Header("Tank Types")]
        public TankType TankType;
        public string TankName;
        public float Speed;
        public float Health;

        [Header("Shooting Parameters")]
        public Scripts.MVC.Tank.BulletType bulletType;
        public float minLaunchForce;
        public float maxLaunchForce;
        public float maxChargeTime;
    }
}