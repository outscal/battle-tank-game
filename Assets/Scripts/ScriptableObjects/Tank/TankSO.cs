using UnityEngine;

[CreateAssetMenu(fileName = "NewTankScriptableObject", menuName = "ScriptableObject/Tank/New Tank ScriptableObject")]
public class TankSO : ScriptableObject
{
    public TankTypes TankType;
    public string TankName;
    public float MovementSpeed;
    public float RotationSpeed;
    public float Health;
    public Color TankColor;
}