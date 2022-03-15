using UnityEngine;

//Summary//
//Creating a Scriptable Object for Tank prefab to inherit data 
//-Summary//
[CreateAssetMenu(fileName = "New EnemyTankData", menuName = "Enemy Tank Data", order = 53)]
public class EnemyTankStats : ScriptableObject
{
    public TankColor type;
    public Bullets btype;
    public int maxHealth;
    public int attackPower;
    public Material color;
}
