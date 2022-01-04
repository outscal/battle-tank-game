using System; 
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "SciptableObjects/NewTankScriptableObject")]
public class TankScriptableObject: ScriptableObject
{
    public string TankName;
    public float Speed;
    public float Health;
/*    public BulletType BulletType;*/
}