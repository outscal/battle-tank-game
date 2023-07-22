using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TanksScriptableObjectList", menuName = "ScriptableObject/NewTankListScriptableObject")]
public class TankTypeScriptableObjectList : ScriptableObject
{
    public List<TankTypeScriptableObject> list = new List<TankTypeScriptableObject>();
}