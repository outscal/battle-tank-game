using UnityEngine;

[ CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject") ]
public class TankScriptableObject : ScriptableObject
{
    public TankType TankType;
    public TankControllerType TankControllerType;
    public BulletType BulletType;
    public int Health;
    public int MovementSpeed;
}


[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}