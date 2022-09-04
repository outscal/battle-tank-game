using TankServices;
using BulletServices;
using UnityEngine;

/// <summary>
/// A class for creating Tank Scriptable Objects with all the required properties.
/// </summary>

namespace TankScriptableObjects
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank/TankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        [Header("Tank Type")]
        public TankType tankType;

        [Header("Tank Prefab Colour")]
        public Color tankColor;

        [Header("Health Parameters")]
        public int tankHealth;

        [Header("Movement Parameters")]
        public float rotationSpeed;
        public float tankSpeed;
        public float turretRotationSpeed;

        [Header("Shooting Parameters")]
        public BulletType bulletType;
        public float minLaunchForce;
        public float maxLaunchForce;
        public float maxChargeTime;
    }
}
