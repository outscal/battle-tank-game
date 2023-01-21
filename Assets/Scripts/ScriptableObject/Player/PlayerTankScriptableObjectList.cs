using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObjectList", menuName = "ScriptableObjects/Player Tank Scriptable Object List")]
public class PlayerTankScriptableObjectList : ScriptableObject
{
    public PlayerTankScriptableObject[] pTanks;
}
