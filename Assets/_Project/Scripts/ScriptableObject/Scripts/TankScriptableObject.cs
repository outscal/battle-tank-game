using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float speed;
    public float tankTurnSpeed;
    public float Health;
    public float damage;
    public Color color;
}