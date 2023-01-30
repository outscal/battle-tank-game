using UnityEngine;


[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObject/NewTank")]
public class TankScriptableObject: ScriptableObject
{
    public TankType TankType;
    public string TankName;
    public float Speed;
    public float RotationSpeed;
    public int Health;
}
