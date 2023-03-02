using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName ="ScriptableObjects/NewTank")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public string tankName;
    public float speed;
    public float rotateSpeed;
    public float jumpValue;
}
