using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NormalEnemySpawnManagerScriptableObject", order = 1)]
public class NormalEnemySpawnManagerScriptableObject : ScriptableObject
{
    public string enemyTankPrefab;
    public float health;
    public int rotationSpeed;
    public float speed;
    public float accuracy;
    public float fireForce;
    public float numberOfShellsPerSeconds;
    public float damage;
    public int score;
    public Material red;
    public int numberOfNormalEnemyTanksToCreate;
    public Vector3 spawnPoint;

}