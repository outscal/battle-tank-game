using System;
using UnityEngine;
using TankServices;
using BulletSO;

namespace TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        [Header("Tank Type Specific")]
        public TankType tankType;

        [Header("MVC Essentials")]
        public TankView tankView;

        [Header("Health Vars")]
        public float health;

        [Header("Movement Vars")]
        public float movementSpeed;
        public float rotationSpeed;

        [Header("Shooting Vars")]
        public float fireRate;
        public BulletScriptableObject bulletType;
        public Material material;

    }

    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/Tank/TankScriptableObjectList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;

    }
}