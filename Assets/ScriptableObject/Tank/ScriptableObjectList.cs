using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableObjectList", menuName = "ScriptableObject/Tank/CreateList")]
public class ScriptableObjectList : ScriptableObject
{
    public TankScriptableObjects[] tank;
}
