using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleScriptableObjectList", menuName = "ScriptableObject/CollectibleScriptableObjectList")]
public class CollectibleScriptableObjectList : ScriptableObject
{
    public CollectibleScriptableObject[] collectibleScriptableObject;
}
