using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MediumEnemySpawnManagerScriptableObject", order = 2)]
public class MediumEnemySpawnManagerScriptableObject : ScriptableObject
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
    public Material blue;
    public int numberOfMediumEnemyTanksToCreate;
    public Vector3 spawnPoint;

}