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
}

//[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
//public class TankScriptableObjectList : ScriptableObject
//{
//    public TankScriptableObject[] tanks;
//}