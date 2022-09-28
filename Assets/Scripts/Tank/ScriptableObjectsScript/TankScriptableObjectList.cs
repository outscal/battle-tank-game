using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TanksList", menuName = "ScriptableObjects/TankListScriptableObject")]
public class TankScriptableObjectList: ScriptableObject
{
    public List<TankScriptableObjectScript> tanks;
}
