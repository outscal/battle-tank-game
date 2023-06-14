using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/CreateNewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType TankType;
    public string TankName;
    public int Speed;
    public int Health;
    public TankView TankView;
}