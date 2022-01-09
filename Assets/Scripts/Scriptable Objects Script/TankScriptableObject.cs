using System; 
using UnityEngine;
using PlayerTankService;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "SciptableObjects/NewTankScriptableObject")]
public class TankScriptableObject: ScriptableObject
{
    public TankView tankView;
    public string TankName;
    public TankType tanktype;
    public Color TankColor;
    public float Speed;
    public float Health;
    public float TurnSpeed;
    /*    public BulletType BulletType;*/
}