
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerTankScriptableObject", menuName ="ScriptableObject/NewPlayerTank")]
public class PlayerTankScriptableObject : ScriptableObject
{
    public PlayerTankTypes TankType;
    public string TankName;
    public float Health;
    public float MovementSpeed;
    public float RotationSpeed;
}


public enum PlayerTankTypes
{
    Null,
    Fast,
    Powerfull
}