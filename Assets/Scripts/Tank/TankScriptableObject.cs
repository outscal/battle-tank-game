using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "TankScriptableObject", menuName = "ScriptableObject/TankScriptableObject")]
public class TankScriptableObject : ScriptableObject {
    
    public TankType tankType;
    public string TankName;
    public int Speed;
    public int Health;    
}




