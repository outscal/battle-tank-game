
using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObject/NewTank")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes tankType;
    public string tankName;
    public float health;
    public float speed;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObject/NewTankList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tankScriptableObjects;
}