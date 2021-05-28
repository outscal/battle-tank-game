using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankColor TankColor;
    public string TankName;
    public float Speed;
    public float Health;
    public float Damage;
    public BulletScriptableObject BulletScriptableObject;
}

