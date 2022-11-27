using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TankType
{

    None = 0,
    Red = 1,
    Green = 2,
    Blue = 3


}
[CreateAssetMenu(menuName = "Create Tank Type", fileName = "NewTankType")]

public class TankTypeSO: ScriptableObject
{
    [Header("Properties")]
    public TankType tankType;
    public float maxHealth;


    [Header("Movement")]
    public float speed;

    [Header("Power")]
    public float damage;

    [Header("material")]
    public Material color;


}
