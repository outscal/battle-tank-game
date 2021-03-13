using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class EnemySpawnManagerScriptableObject : ScriptableObject
{
    public string enemyTankPrefab;
    public float health;
    public int patrolLevel;
    public int speed;

    public int numberOfPrefabsToCreate;
    public Vector3 spawnPoint;
}