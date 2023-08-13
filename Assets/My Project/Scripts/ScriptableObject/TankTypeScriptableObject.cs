using System;
using UnityEngine;


[CreateAssetMenu(fileName = "Create Tank Type", menuName = "New Tank Type")]
public class TankTypeScriptableObject : ScriptableObject
{
    [Header("Proprties")]
    public TankType tankType;
 
    public int maxhealth;

    [Header("Movement")]
    public float speed;

    [Header("Power")]
    public float Damage;

    [Header("Material")]
    public Material color;

}
