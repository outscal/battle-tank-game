using System;
using UnityEngine;
using TankServices;

namespace TankSO
{
    [CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/NewTankScriptableObject")]
    public class TankScriptableObject : ScriptableObject
    {
        [Header("Tank Type Specific")]
        public TankType tankType;
        public MeshRenderer[] meshObjects;



        [Header("MVC Essentials")]
        public TankView tankView;

        [Header("Health Vars")]
        public float health;

        [Header("Movement Vars")]
        public float movementSpeed;
        public float rotationSpeed;

        [Header("Shooting Vars")]
        public float fireRate;

    }

    [CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/TankScriptableObjectList")]
    public class TankScriptableObjectList : ScriptableObject
    {
        public TankScriptableObject[] tanks;
    }


}