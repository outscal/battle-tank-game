using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObject", menuName = "ScriptableObjects/Player Tank Scriptable Object")]
public class PlayerTankScriptableObject : ScriptableObject
{
    public PlayerTankType pTankType;
    public float Speed;
    public float RotationSpeed;
    public float Health;
    public float Damage;
    public GameObject prefab;
}
