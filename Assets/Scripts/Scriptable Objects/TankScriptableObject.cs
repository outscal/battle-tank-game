using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes TankTypes;
    public TankController TankController;
    public BulletType BulletType;
    public int Health;
    public int Speed;
    public int RotationRate;
    public int TurretRotationRate;
}


[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}