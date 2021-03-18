using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/HardEnemySpawnManagerScriptableObject", order = 3)]
public class HardEnemySpawnManagerScriptableObject : ScriptableObject
{
    public string enemyTankPrefab;
    public float health;
    public float rotationSpeed;
    public float speed;
    public float accuracy;
    public float fireForce;
    public float numberOfShellsPerSeconds;
    public float damage;
    public int score;
    public Material yellow;
    public int numberOfHardEnemyTanksToCreate;
    public Vector3 spawnPoint;

}