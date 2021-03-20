using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TankConfig", order = 1)]
public class TankConfig : ScriptableObject
{
    public new string name;
    public float health;
    public float rotationSpeed;
    public float speed;
    public float accuracy;
    public float fireForce;
    public float numberOfShellsPerSeconds;
    public float damage;
    public int score;
    public Material color;
    public int numberOfTanksToCreate;
    public Vector3 spawnPoint;
    public bool isDead;

}