using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObjects/NewTank")]
public class TankScriptableObjects : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public int speed;
    public int health;
}
