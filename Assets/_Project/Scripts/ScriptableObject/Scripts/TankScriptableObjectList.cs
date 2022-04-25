using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObjectList", menuName = "ScriptableObjects/NewTankListScriptableObject")]
public class TankScriptableObjectList : ScriptableObject
{
    public TankScriptableObject[] tanks;
}
