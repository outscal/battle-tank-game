using UnityEngine;

[CreateAssetMenu(fileName ="TankScriptableObject", menuName = "ScriptableObjects/NewTankScriptableObject")]
public class TankScriptableObject : ScriptableObject
{
    public TankType tankType;
    public Vector3 scale;
    public string tankName;
    public float speed;
    public float tankTurnSpeed;
    public float Health;
    public float damage;
    public Color color;

    public float minLaunchForce;// = 15f;
    public float maxLaunchForce = 30f;
    public float maxChargeTime = 0.75f;

    public float currentLaunchForce;
    public float chargeSpeed;

    //private float prabath;
}