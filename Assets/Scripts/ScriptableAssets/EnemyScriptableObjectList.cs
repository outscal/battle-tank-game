using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObject/EnemyScriptableObjectList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] enemyScriptableObject;

}
