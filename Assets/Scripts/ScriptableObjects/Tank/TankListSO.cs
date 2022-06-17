using UnityEngine;

[CreateAssetMenu(fileName = "NewTankScriptableObjectList", menuName = "ScriptableObject/Tank/New TankList ScriptableObject")]
public class TankListSO : ScriptableObject
{
    public TankSO[] tanks;
}