using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObjectList", menuName = "ScriptableObjects/NewEnemyScriptableObjectList")]
public class EnemyScriptableObjectList : ScriptableObject
{
    public EnemyScriptableObject[] enemies;
}
