using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
public class TankScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public int damage;
    public GameObject tankPrefab;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}
