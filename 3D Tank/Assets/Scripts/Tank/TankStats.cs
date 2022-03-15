using UnityEngine;

//Summary//
//Creating a Scriptable Object for Tank prefab to inherit data 
//-Summary//
[CreateAssetMenu(fileName = "New TankData", menuName = "Tank Data", order = 51)]
public class TankStats : ScriptableObject
{
    public TankColor type;
    public Bullets btype;
    public int maxHealth;
    public int attackPower;
}


