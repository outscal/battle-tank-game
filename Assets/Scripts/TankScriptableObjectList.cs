using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
public class TankScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public int damage;
    public TankView tankView;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}
