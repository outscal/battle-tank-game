using BulletServices;
using PlayerTankServices;
using UnityEngine;

namespace TankSO
{
    [ CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank/TankScriptableObject") ]
    public class TankScriptableObject : ScriptableObject
    {
        [Header("Tank Type")]
        public TankType tankType;

        [Header("Tank Prefab")]
        public Color tankColor;

        [Header("Health Parameters")]
        public int health;

        [Header("Movement Parameters")]
        public float movementSpeed;
        public float rotationSpeed;
        public float turretRotationRate;

        [Header("Shooting Parameters")]
        public BulletType bulletType;
        public float minLaunchForce;
        public float maxLaunchForce;
        public float maxChargeTime;  
    }
}

