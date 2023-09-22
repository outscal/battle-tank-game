using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObjects")]
public class TankScriptableObject : ScriptableObject
{
    public TankTypes type;
    public float speed;
    public float health;
    public float damage;
    public TankView tankView;
}
