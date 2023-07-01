using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTank")]
public class TankScriptableObject : ScriptableObject
{
    public int health;
    public int speed;
    public BulletType bulletType;
    public TankView tankView;
}

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankObjectList")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}
